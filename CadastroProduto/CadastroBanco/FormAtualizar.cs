using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroBanco
{
    public partial class FormAtualizar : Form
    {
        public string Categoria { get; private set; }
        public string Descricao { get; private set; }
        public decimal Qnt { get; private set; }
        public decimal Preco { get; private set; }
        public FormAtualizar(string categoria, string descricao, decimal qnt, decimal preco)
        {
            InitializeComponent();
            cbCategoria.Text = categoria;
            txtDesc.Text = descricao;
            numQnt.Value = qnt;
            numPreco.Value = preco;
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
        }
        private void FormAtualizar_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            // Salvar as alterações
            Categoria = cbCategoria.Text;
            Descricao = txtDesc.Text;
            Qnt = numQnt.Value;
            Preco = numPreco.Value;

            this.DialogResult = DialogResult.OK; // Retornar OK para confirmar a atualização
            this.Close();
        }
    }
}
