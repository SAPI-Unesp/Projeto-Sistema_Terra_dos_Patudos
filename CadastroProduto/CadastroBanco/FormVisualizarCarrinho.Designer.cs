namespace CadastroBanco
{
    partial class FormVisualizarCarrinho
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewDados = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdVendida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnFinalizarCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDados)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDados
            // 
            this.dataGridViewDados.AllowUserToAddRows = false;
            this.dataGridViewDados.AllowUserToDeleteRows = false;
            this.dataGridViewDados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewDados.ColumnHeadersHeight = 40;
            this.dataGridViewDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.categoria,
            this.descricao,
            this.quantidade,
            this.preco,
            this.qtdVendida});
            this.dataGridViewDados.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewDados.MultiSelect = false;
            this.dataGridViewDados.Name = "dataGridViewDados";
            this.dataGridViewDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDados.Size = new System.Drawing.Size(801, 408);
            this.dataGridViewDados.TabIndex = 10;
            this.dataGridViewDados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDados_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 30;
            // 
            // categoria
            // 
            this.categoria.HeaderText = "Categoria";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            this.categoria.Width = 75;
            // 
            // descricao
            // 
            this.descricao.HeaderText = "Peça";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 300;
            // 
            // quantidade
            // 
            this.quantidade.HeaderText = "Quantidade em Estoque";
            this.quantidade.Name = "quantidade";
            this.quantidade.ReadOnly = true;
            this.quantidade.Width = 150;
            // 
            // preco
            // 
            this.preco.HeaderText = "Preço";
            this.preco.Name = "preco";
            this.preco.ReadOnly = true;
            // 
            // qtdVendida
            // 
            this.qtdVendida.HeaderText = "Quantidade Vendida";
            this.qtdVendida.Name = "qtdVendida";
            this.qtdVendida.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(93, 426);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 40);
            this.btnRemover.TabIndex = 11;
            this.btnRemover.Text = "Remover do carrinho";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnFinalizarCompra
            // 
            this.btnFinalizarCompra.Location = new System.Drawing.Point(12, 426);
            this.btnFinalizarCompra.Name = "btnFinalizarCompra";
            this.btnFinalizarCompra.Size = new System.Drawing.Size(75, 40);
            this.btnFinalizarCompra.TabIndex = 12;
            this.btnFinalizarCompra.Text = "Finalizar compra";
            this.btnFinalizarCompra.UseVisualStyleBackColor = true;
            this.btnFinalizarCompra.Click += new System.EventHandler(this.btnFinalizarCompra_Click);
            // 
            // FormVisualizarCarrinho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 533);
            this.Controls.Add(this.btnFinalizarCompra);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.dataGridViewDados);
            this.Name = "FormVisualizarCarrinho";
            this.Text = "FormVisualizarCarrinho";
            this.Load += new System.EventHandler(this.FormVisualizarCarrinho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn preco;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdVendida;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnFinalizarCompra;
    }
}