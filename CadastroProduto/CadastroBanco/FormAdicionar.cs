using CadastroBanco;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CadastroBanco
{
    public partial class FormAdicionar : Form
    {
        private Form2 formPrincipal; // Referência ao Form1 (formulário principal)
        string caminhoArquivo = "dados.txt"; // Mesmo arquivo usado no Form1
        string caminhoArquivoCategoria = "categoria.txt";
        public string cbtexto;
        public FormAdicionar(Form2 form)
        {
            InitializeComponent();
            this.formPrincipal = form; // Recebe a referência do Form2
            if (File.Exists(caminhoArquivoCategoria))
            {
                var linhas = File.ReadAllLines(caminhoArquivoCategoria);
                foreach (var linha in linhas)
                {
                   
                 cbCategoria.Items.Add(linha);
                    
                }
            }
          
        }

        // Botão para confirmar e adicionar os dados ao arquivo TXT
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
        }

        private void FormAdicionar_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            string pagLivro = ObterProximoIdLivroDisponivel();
                string categoria = cbCategoria.Text;
                cbtexto = categoria;
                string descricao = txtDesc.Text;
                decimal qnt = numQnt.Value;
                decimal preco = numPreco.Value;

            if (File.Exists(caminhoArquivoCategoria))
            {
                // Lê todas as linhas do arquivo
                var categorias = File.ReadAllLines(caminhoArquivoCategoria);

                // Verifica se a categoria está presente
                if (!categorias.Contains(categoria))
                {
                    // A categoria não está no arquivo
                    //MessageBox.Show("Categoria não encontrada.");
                    File.AppendAllText(caminhoArquivoCategoria, $"{categoria}{Environment.NewLine}");
                }
             
            }
            else
            {
                File.WriteAllText(caminhoArquivoCategoria, $"{categoria}{Environment.NewLine}");
            }
       

            if (string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Preencha a categoria.");
                return;
            }

            int proximoId = ObterProximoIdDisponivel();

            // Adiciona ao arquivo
            File.AppendAllText(caminhoArquivo, $"{proximoId}*{pagLivro}*{categoria}*{descricao}*{qnt}*{preco}*{DateTime.Now}*a vender*{Environment.NewLine}");
            MessageBox.Show("Dados adicionados com sucesso!");

            // Atualiza o DataGridView no formulário principal
            formPrincipal.ExibirDados();

            // Fecha o formulário de adição após a inserção
            this.Close();
        }
        private int ObterProximoIdDisponivel()
        {
            // Se o arquivo não existir, o primeiro ID será 1
            if (!File.Exists(caminhoArquivo))
                return 1;

            // Ler todas as linhas do arquivo
            var linhas = File.ReadAllLines(caminhoArquivo);

            // Extrair os IDs existentes (supondo que o ID está na primeira coluna)
            var idsExistentes = linhas
                .Where(l => !string.IsNullOrWhiteSpace(l)) // Ignorar linhas vazias
                .Select(l => int.Parse(l.Split('*')[0].Trim())) // Pegar o ID (primeiro campo)
                .OrderBy(id => id) // Ordenar por ID
                .ToList();

            // Encontrar o menor ID não utilizado
            int proximoId = 0; // Começa com o ID 1
            foreach (var id in idsExistentes)
            {
                if (id == proximoId)
                    proximoId++; // Se o ID atual já está em uso, incrementar
                else
                    break; // Encontrar o menor ID não usado
            }

            return proximoId;
        }

        private string ObterProximoIdLivroDisponivel()
        {
            // Se o arquivo não existir, o primeiro ID será "00A-00"
            if (!File.Exists(caminhoArquivo))
                return "00A-00";

            // Ler todas as linhas do arquivo
            var linhas = File.ReadAllLines(caminhoArquivo);

            // Extrair os IDs existentes (supondo que o ID está no segundo campo)
            var idsExistentes = linhas
                .Where(l => !string.IsNullOrWhiteSpace(l)) // Ignorar linhas vazias
                .Select(l => l.Split('*')[1].Trim()) // Pegar o segundo campo, que contém o ID
                .ToList();
            Debug.Log(" ");
            // Ordenar os IDs
            idsExistentes.Sort();

            // Encontrar o próximo ID disponível
            string proximoId = "00A-00"; // Começa com o ID "00A-00"

            foreach (var id in idsExistentes)
            {
                var partes = id.Split('-');
                string parteAlfa = partes[0]; // Ex: "13A"
                string parteNum = partes[1];

                // Verifica se a parte numérica é menor que 26
                int parteNumn = int.Parse(parteNum);
                if (int.Parse(parteNum) < 26)
                {
                    parteNumn++;
                }
                else
                {
                    parteNumn = 0; // Redefine para 0
                                  // Incrementa a parte alfabética
                    char letra = parteAlfa[parteAlfa.Length - 1]; // Última letra
                    int numero = int.Parse(parteAlfa.Substring(0, parteAlfa.Length - 1)); // Parte numérica
                    if (letra < 'Z')
                    {
                        letra++; // Incrementa a letra
                    }
                    else
                    {
                        letra = 'A'; // Redefine a letra
                        numero++; // Incrementa o número
                    }
                    parteAlfa = $"{numero}{letra}"; // Monta a nova parte alfabética
                }

                // Monta o novo ID atualizado
                var novoId = $"{parteAlfa}-{parteNumn:D2}"; // Formata a parte numérica com dois dígitos

                // Verifica se o novo ID já está em uso
                if (novoId != id)
                {
                    proximoId = novoId; // Atualiza o próximo ID disponível
                    break; // Para assim que encontrar um ID disponível
                }
            }

            return proximoId;
        }




        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
