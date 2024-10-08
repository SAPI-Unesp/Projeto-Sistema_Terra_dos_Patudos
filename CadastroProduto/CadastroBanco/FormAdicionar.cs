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
            this.formPrincipal = form; // Recebe a referência do Form1
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
            File.AppendAllText(caminhoArquivo, $"{proximoId}* {categoria}* {descricao}* {qnt}* {preco}*{DateTime.Now}{Environment.NewLine}");
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
            int proximoId = 1; // Começa com o ID 1
            foreach (var id in idsExistentes)
            {
                if (id == proximoId)
                    proximoId++; // Se o ID atual já está em uso, incrementar
                else
                    break; // Encontrar o menor ID não usado
            }

            return proximoId;
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
