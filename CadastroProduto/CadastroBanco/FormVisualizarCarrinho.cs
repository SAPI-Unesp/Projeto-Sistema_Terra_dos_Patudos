using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CadastroBanco
{
    public partial class FormVisualizarCarrinho : Form
    {

        string caminhoArquivo = "dados.txt"; // Arquivo onde os dados serão armazenados
        string caminhoArquivoVendas = "Vendas.txt"; // Arquivo onde os dados serão armazenados
        string caminhoArquivoCategoria = "categoria.txt";
        string caminhoArquivoCarrinho = "carrinho.txt";
        string caminhoArquivoCliente = "cliente.txt";
        string itensComId = "itensComId.txt";
        public FormVisualizarCarrinho()
        {
            InitializeComponent();
        }

        private void FormVisualizarCarrinho_Load(object sender, EventArgs e)
        {
            ExibirDados();
            calcularTotal();
            cbPagamento.SelectedIndex = 0;
            //cbFormapagamento.SelectedIndex = 0;
        }

        private int ObterProximoIdVendasDisponivel()
        {
            // Se o arquivo não existir, o primeiro ID será 0
            if (!File.Exists(caminhoArquivoVendas))
                return 0;

            // Ler todas as linhas do arquivo
            var linhas = File.ReadAllLines(caminhoArquivoVendas);

            var idsExistentes = linhas
                .Where(l => !string.IsNullOrWhiteSpace(l))// ignora linhas vazias
                .Select(l => l.Split('*'))// divide os campos
                .Where(partes => partes.Length > 1)// garante que tem ao menos dois campos
                .Select(partes => int.Parse(partes[1].Trim()))// pega o segundo campo como int
                .Distinct()// remove duplicatas
                .OrderBy(id => id)// ordena
                .ToList();


            int proximoId = 0; 
            foreach (var id in idsExistentes)
            {
                if (id == proximoId)
                    proximoId++; // Se o ID atual já está em uso, incrementar
                else
                    break; // Encontrar o menor ID não usado
            }

            return proximoId;
        }

        /*
        private int ObterProximoIdDisponivel()
        {
            // Se o arquivo não existir, o primeiro ID será 0
            if (!File.Exists(caminhoArquivoVendas))
                return 0;

            // Ler todas as linhas do arquivo
            var linhas = File.ReadAllLines(caminhoArquivoVendas);

            // Extrair os IDs existentes (supondo que o ID está na primeira coluna)
            var idsExistentes = linhas
                .Where(l => !string.IsNullOrWhiteSpace(l)) // Ignorar linhas vazias
                .Select(l => int.Parse(l.Split('*')[1].Trim())) // Pegar o ID (primeiro campo)
                .OrderBy(id => id) // Ordenar por ID
                .ToList();

            int proximoId = 0;
            foreach (var id in idsExistentes)
            {
                if (id == proximoId)
                    proximoId++; // Se o ID atual já está em uso, incrementar
                else
                    break; // Encontrar o menor ID não usado
            }

            return proximoId;
        }
        */

        public void AddCliente()
        {
            var linhasVendas = File.ReadAllLines(caminhoArquivoVendas);

            List<string> linhasClientes = new List<string>();
            if (!File.Exists(caminhoArquivoCliente))
            {
                File.WriteAllText(caminhoArquivoCliente, "");
            }

            linhasClientes = File.ReadAllLines(caminhoArquivoCliente).ToList();

            foreach (var linhaVenda in linhasVendas)
            {
                var dadosVenda = linhaVenda.Split('*');
                if (dadosVenda.Length >= 10)
                {
                    string precoVenda = dadosVenda[5].Trim();
                    string pessoa = dadosVenda[7].Trim();
                    string telefonep = dadosVenda[8].Trim();

                    bool clienteExistente = false;

                    for (int j = 0; j < linhasClientes.Count; j++)
                    {
                        var dadosCliente = linhasClientes[j].Split('*');
                        string cliente = dadosCliente[1].Trim();
                        string telefone = dadosCliente[2].Trim();
                        string desconto = dadosCliente[4].Trim();
                        string credito = dadosCliente[5].Trim();

                        if (pessoa.Equals(cliente))
                        {
                            clienteExistente = true;


                            linhasClientes[j] = $"{j}*{cliente}*{telefone}*0*{desconto}*{credito}";

                            break;
                        }
                    }

                    if (!clienteExistente && pessoa != "")
                    {
                        string novaLinhaCliente = $"{linhasClientes.Count}*{pessoa}*{telefonep}*0*0*0";
                        linhasClientes.Add(novaLinhaCliente);
                    }
                }
            }

            File.WriteAllLines(caminhoArquivoCliente, linhasClientes);

            linhasClientes = File.ReadAllLines(caminhoArquivoCliente).ToList();
            var linhasCliente2 = File.ReadAllLines(caminhoArquivoCliente).ToList();

            foreach (var linha in linhasClientes)
            {
                var dadosCliente = linha.Split('*');
                string id = dadosCliente[0].Trim();
                string cliente = dadosCliente[1].Trim();
                string telefone = dadosCliente[2].Trim();
                string desconto = dadosCliente[4].Trim();
                string credito = dadosCliente[5].Trim();
                decimal valorDivida = 0;

                foreach (var linhaV in linhasVendas)
                {
                    var dadosVenda = linhaV.Split('*');

                    if (dadosVenda.Length >= 10)
                    {
                        string precoVenda = dadosVenda[5].Trim();
                        string pessoa = dadosVenda[7].Trim();

                        if (pessoa.Equals(cliente))
                        {
                            valorDivida += decimal.Parse(precoVenda);
                        }
                    }
                }
                int linhasParaAtualizar = linhasClientes.FindIndex(l => l.StartsWith(id + "*"));

                linhasCliente2[linhasParaAtualizar] = $"{id}*{cliente}*{telefone}*{valorDivida.ToString()}*{desconto}*{credito}";
            }

            File.WriteAllLines(caminhoArquivoCliente, linhasCliente2);
        }

        public void ExibirDados()
        {
            dataGridViewDados.Rows.Clear(); // Limpa as linhas antes de exibir

            if (File.Exists(caminhoArquivoCarrinho))
            {
                var linhas = File.ReadAllLines(caminhoArquivoCarrinho);
                var linhasD = File.ReadAllLines(caminhoArquivo);
                foreach (var linha in linhas)
                {
                    foreach (var linhaD in linhasD)
                    {
                        var dadosD = linhaD.Split('*');

                        if (dadosD.Length == 9 && (dadosD[0].Trim() == linha))
                        {
                            string id = dadosD[0].Trim();
                            string livro = dadosD[1].Trim();
                            string categoria = dadosD[2].Trim();
                            string descricao = dadosD[3].Trim();
                            string qnt = dadosD[4].Trim();
                            string preco = dadosD[5].Trim();

                            dataGridViewDados.Rows.Add(id, livro, categoria, descricao, qnt, preco, 1);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhum dado encontrado.");
            }

        }
        private void dataGridViewDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void calcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridViewDados.Rows)
            {
                string qtdV;
                string preco = row.Cells[5].Value.ToString();
                if (!row.Cells[6].Value.ToString().All(char.IsDigit))
                {
                    qtdV = "1";
                    row.Cells[6].Value = "1";
                }
                else
                {
                    qtdV = row.Cells[6].Value.ToString();
                }

                total += Convert.ToDecimal(preco) * Convert.ToDecimal(qtdV);
            }

            tbTotalPagar.Text = total.ToString();
        }

        private void dataGridViewDados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calcularTotal();
        }


        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dataGridViewDados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para deletar.");
                return;
            }

            if (dataGridViewDados.SelectedRows.Count > 1)
            {
                MessageBox.Show("Selecione apenas um item.");
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Você tem certeza que deseja deletar este item do carrinho?",
                                                         "Confirmação de Exclusão",
                                                         MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // Se o usuário confirmar, excluir o item
                int index = dataGridViewDados.SelectedRows[0].Index;
                var linhaSelecionada = dataGridViewDados.Rows[index];

                string id = linhaSelecionada.Cells[0].Value.ToString(); // Pega o ID

                var linhas = File.ReadAllLines(caminhoArquivoCarrinho).ToList();

                // Encontra a linha correspondente pelo ID
                int linhaParaDeletar = linhas.FindIndex(l => l.StartsWith(id));
                if (linhaParaDeletar >= 0)
                {
                    linhas.RemoveAt(linhaParaDeletar); // Remove o item correspondente ao ID
                    File.WriteAllLines(caminhoArquivoCarrinho, linhas);
                    ExibirDados(); // Recarregar os dados no DataGridView
                }
                else
                {
                    MessageBox.Show("Erro ao encontrar o item para deletar.");
                }
            }

            ExibirDados();
        }

        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            if (cbPagamento.SelectedIndex == 1)
            {
                if (string.IsNullOrEmpty(nome.Text))
                {
                    MessageBox.Show("O nome não pode estar vazio");
                    return;
                }
                if (string.IsNullOrEmpty(telefone.Text))
                {
                    MessageBox.Show("O telefone não pode estar vazio");
                    return;
                }
            }

            string nomedocliente = nome.Text;
            string telefonedocliente = telefone.Text;

            var linhasClient = File.ReadAllLines(caminhoArquivoCliente);
            foreach (var linha in linhasClient)
            {
                var dados = linha.Split('*');
                // Certifique-se de que há 10 campos (categoria, descrição, quantidade, preço) // agr to pegando o id junto já q ele tá iterável
                if (dados.Length == 5)
                {
                    string nomeC = dados[2].Trim();
                    string telefoneC = dados[3].Trim();
                    if (nomedocliente == nomeC)
                    {
                        DialogResult confirmResult = MessageBox.Show("Cliente já existe na base de dados, este é o mesmo cliente?", 
                                                         "Confirmação de existência",
                                                         MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {
                            nomedocliente = nomeC;
                            telefonedocliente = telefoneC;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Digite outro nome para o cliente");
                            return;
                        }
                    }
                }
            
            }

            

            foreach (DataGridViewRow row in dataGridViewDados.Rows)
            {
                string qtdE = row.Cells[4].Value.ToString();
                string qtdV = row.Cells[6].Value.ToString();
                if (!qtdV.All(char.IsDigit))
                {
                    MessageBox.Show("A quantidade vendida precisa ser um número");
                    return;
                }
                if (Convert.ToInt32(qtdE) < Convert.ToInt32(qtdV))
                {
                    MessageBox.Show("Quantidade no estoque é menor que a quantidade vendida");
                    return;
                }
            }

            var linhas = File.ReadAllLines(caminhoArquivo);
            var linhasl = File.ReadAllLines(caminhoArquivo).ToList();
            var linhasV = File.ReadAllLines(caminhoArquivoVendas);

            foreach (DataGridViewRow row in dataGridViewDados.Rows)
            {
                decimal qtdV = Convert.ToInt32(row.Cells[6].Value.ToString());
                decimal precop = Convert.ToDecimal(row.Cells[5].Value.ToString());
                decimal total = precop * qtdV;
                string qnt = (Convert.ToInt32(row.Cells[4].Value.ToString()) - qtdV).ToString();
                string id = row.Cells[0].Value.ToString();
                string data = null;
                string paga = null;

                int linhaParaAtualizar = linhasl.FindIndex(l => l.StartsWith(id + "*"));

                foreach (var linha in linhas)
                {
                    var dados = linha.Split('*');

                    if (dados[0].Trim() == id)
                    {
                        data = dados[6].Trim();
                        paga = dados[7].Trim();
                        break;
                    }
                }

                if (linhaParaAtualizar >= 0)
                {
                    // Atualizar a linha com os novos dados
                    linhas[linhaParaAtualizar] = $"{id}*{row.Cells[1].Value.ToString()}*{row.Cells[2].Value.ToString()}*{row.Cells[3].Value.ToString()}*{qnt}*{precop}*{data}*{paga}*";

                    // Escrever as alterações no arquivo
                    File.WriteAllLines(caminhoArquivo, linhas);
                }

                //int idV = ObterProximoIdVendasDisponivel();

                if (cbPagamento.Text.Equals("Pendente"))
                {
                    File.AppendAllText(caminhoArquivoVendas, $"{id}*{ObterProximoIdVendasDisponivel()}*{row.Cells[1].Value.ToString()}*{row.Cells[2].Value.ToString()}*{row.Cells[3].Value.ToString() + " " + comboBox1.Text + " - Pagamento para : " + dataPrazo.Value.ToString()}*{qtdV.ToString()}*{total.ToString()}*{DateTime.Now}*{nomedocliente}*{telefonedocliente}*{cbPagamento.Text}{Environment.NewLine}");
                }else if (cbPagamento.Text.Equals("Realizado"))
                {
                    File.AppendAllText(caminhoArquivoVendas, $"{id}*{ObterProximoIdVendasDisponivel()}*{row.Cells[1].Value.ToString()}*{row.Cells[2].Value.ToString()}*{row.Cells[3].Value.ToString() + " " + comboBox1.Text}*{qtdV.ToString()}*{total.ToString()}*{DateTime.Now}*{nomedocliente}*{telefonedocliente}*{cbPagamento.Text}{Environment.NewLine}");
                }
                AddCliente();
            }

            File.Delete(caminhoArquivoCarrinho);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CbPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPagamento.SelectedIndex == 0)
            {
                //nome.Enabled = false;
                nome.Text = null;
                telefone.Enabled = false;
                telefone.Text = null;
                dataPrazo.Enabled = false;
            }

            if (cbPagamento.SelectedIndex == 1)
            {
                //nome.Enabled = true;
                telefone.Enabled = true;
                dataPrazo.Enabled = true;

            }
        }

        private void tbTotalPagar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimparCarrinho_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Você tem certeza que deseja deletar este carrinho?",
                                                         "Confirmação de Exclusão",
                                                         MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                File.Delete(caminhoArquivoCarrinho);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string forma = comboBox1.Text;
            string formaPag = "";

            var linhas = File.ReadAllLines(caminhoArquivo);
            var linhasl = File.ReadAllLines(caminhoArquivo).ToList();
            var linhasV = File.ReadAllLines(caminhoArquivoVendas);

            foreach (DataGridViewRow row in dataGridViewDados.Rows)
            {
               formaPag = forma + " " + row.Cells[4].Value.ToString();
               
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.youtube.com/watch?v=35rYnRX_8J8&list=PLhEZRWtYRMyt4enwYFTX7io5NHKbluSaG")
            { UseShellExecute = true });
        }
    }
}