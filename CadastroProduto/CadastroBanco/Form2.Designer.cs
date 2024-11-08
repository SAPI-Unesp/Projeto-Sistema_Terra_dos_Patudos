namespace CadastroBanco
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtIdade = new System.Windows.Forms.TextBox();
            this.btnExibir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.dataGridViewDados = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idlivro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataAdicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siatuacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabelaVenda = new System.Windows.Forms.Button();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.imgAddCarrinho = new System.Windows.Forms.PictureBox();
            this.imgVerCarrinho = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAddCarrinho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVerCarrinho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar produto";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdicionar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdicionar.Location = new System.Drawing.Point(19, 548);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(99, 40);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click_1);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(65, 250);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);
            this.txtNome.TabIndex = 3;
            // 
            // txtIdade
            // 
            this.txtIdade.Location = new System.Drawing.Point(65, 276);
            this.txtIdade.Name = "txtIdade";
            this.txtIdade.Size = new System.Drawing.Size(100, 20);
            this.txtIdade.TabIndex = 4;
            // 
            // btnExibir
            // 
            this.btnExibir.BackColor = System.Drawing.Color.Silver;
            this.btnExibir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExibir.Location = new System.Drawing.Point(594, 26);
            this.btnExibir.Name = "btnExibir";
            this.btnExibir.Size = new System.Drawing.Size(67, 40);
            this.btnExibir.TabIndex = 5;
            this.btnExibir.Text = "Exibir";
            this.btnExibir.UseVisualStyleBackColor = false;
            this.btnExibir.Click += new System.EventHandler(this.btnExibir_Click_1);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAtualizar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAtualizar.Location = new System.Drawing.Point(215, 548);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(95, 40);
            this.btnAtualizar.TabIndex = 6;
            this.btnAtualizar.Text = "Editar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click_1);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeletar.BackColor = System.Drawing.Color.Salmon;
            this.btnDeletar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeletar.Location = new System.Drawing.Point(124, 548);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(85, 40);
            this.btnDeletar.TabIndex = 7;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click_1);
            // 
            // dataGridViewDados
            // 
            this.dataGridViewDados.AllowUserToAddRows = false;
            this.dataGridViewDados.AllowUserToDeleteRows = false;
            this.dataGridViewDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewDados.ColumnHeadersHeight = 40;
            this.dataGridViewDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idlivro,
            this.categoria,
            this.descricao,
            this.quantidade,
            this.preco,
            this.dataAdicao,
            this.siatuacao});
            this.dataGridViewDados.Location = new System.Drawing.Point(15, 98);
            this.dataGridViewDados.MultiSelect = false;
            this.dataGridViewDados.Name = "dataGridViewDados";
            this.dataGridViewDados.ReadOnly = true;
            this.dataGridViewDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDados.Size = new System.Drawing.Size(945, 444);
            this.dataGridViewDados.TabIndex = 9;
            this.dataGridViewDados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDados_CellContentClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.FillWeight = 72.16494F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // idlivro
            // 
            this.idlivro.HeaderText = "Pag do Livro";
            this.idlivro.Name = "idlivro";
            this.idlivro.ReadOnly = true;
            // 
            // categoria
            // 
            this.categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.categoria.FillWeight = 104.6392F;
            this.categoria.HeaderText = "Categoria";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.FillWeight = 104.6392F;
            this.descricao.HeaderText = "Peça";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // quantidade
            // 
            this.quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.quantidade.FillWeight = 104.6392F;
            this.quantidade.HeaderText = "Quantidade em Estoque";
            this.quantidade.Name = "quantidade";
            this.quantidade.ReadOnly = true;
            // 
            // preco
            // 
            this.preco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.preco.FillWeight = 104.6392F;
            this.preco.HeaderText = "Preço";
            this.preco.Name = "preco";
            this.preco.ReadOnly = true;
            // 
            // dataAdicao
            // 
            this.dataAdicao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataAdicao.FillWeight = 104.6392F;
            this.dataAdicao.HeaderText = "Data de Adição";
            this.dataAdicao.Name = "dataAdicao";
            this.dataAdicao.ReadOnly = true;
            // 
            // siatuacao
            // 
            this.siatuacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.siatuacao.FillWeight = 104.6392F;
            this.siatuacao.HeaderText = "Situação";
            this.siatuacao.Name = "siatuacao";
            this.siatuacao.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(15, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 26);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tabelaVenda
            // 
            this.tabelaVenda.BackColor = System.Drawing.Color.Silver;
            this.tabelaVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabelaVenda.Location = new System.Drawing.Point(513, 25);
            this.tabelaVenda.Name = "tabelaVenda";
            this.tabelaVenda.Size = new System.Drawing.Size(75, 40);
            this.tabelaVenda.TabIndex = 13;
            this.tabelaVenda.Text = "Vendas";
            this.tabelaVenda.UseVisualStyleBackColor = false;
            this.tabelaVenda.Click += new System.EventHandler(this.tabelaVenda_Click);
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(15, 64);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(150, 28);
            this.cbCategoria.TabIndex = 14;
            this.cbCategoria.SelectedIndexChanged += new System.EventHandler(this.cbCategoria_SelectedIndexChanged);
            // 
            // btnCliente
            // 
            this.btnCliente.BackColor = System.Drawing.Color.Silver;
            this.btnCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.Location = new System.Drawing.Point(432, 25);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(75, 40);
            this.btnCliente.TabIndex = 17;
            this.btnCliente.Text = "Clientes";
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnImprimir.Location = new System.Drawing.Point(863, 548);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(95, 40);
            this.btnImprimir.TabIndex = 18;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // imgAddCarrinho
            // 
            this.imgAddCarrinho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgAddCarrinho.ErrorImage = global::CadastroBanco.Properties.Resources.adionar_no_carrinho;
            this.imgAddCarrinho.Image = global::CadastroBanco.Properties.Resources.adionar_no_carrinho;
            this.imgAddCarrinho.Location = new System.Drawing.Point(789, 19);
            this.imgAddCarrinho.Name = "imgAddCarrinho";
            this.imgAddCarrinho.Size = new System.Drawing.Size(88, 53);
            this.imgAddCarrinho.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgAddCarrinho.TabIndex = 19;
            this.imgAddCarrinho.TabStop = false;
            this.imgAddCarrinho.Click += new System.EventHandler(this.imgAddCarrinho_Click);
            // 
            // imgVerCarrinho
            // 
            this.imgVerCarrinho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgVerCarrinho.ErrorImage = global::CadastroBanco.Properties.Resources.adionar_no_carrinho;
            this.imgVerCarrinho.Image = global::CadastroBanco.Properties.Resources.ver_carrinho;
            this.imgVerCarrinho.Location = new System.Drawing.Point(872, 19);
            this.imgVerCarrinho.Name = "imgVerCarrinho";
            this.imgVerCarrinho.Size = new System.Drawing.Size(88, 53);
            this.imgVerCarrinho.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgVerCarrinho.TabIndex = 20;
            this.imgVerCarrinho.TabStop = false;
            this.imgVerCarrinho.Click += new System.EventHandler(this.imgVerCarrinho_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::CadastroBanco.Properties.Resources.adionar_no_carrinho;
            this.pictureBox1.Image = global::CadastroBanco.Properties.Resources.Search_alt_fill_2x;
            this.pictureBox1.Location = new System.Drawing.Point(356, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(970, 600);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.imgVerCarrinho);
            this.Controls.Add(this.imgAddCarrinho);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.tabelaVenda);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridViewDados);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnExibir);
            this.Controls.Add(this.txtIdade);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Sistema Bazar";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAddCarrinho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVerCarrinho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtIdade;
        private System.Windows.Forms.Button btnExibir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.DataGridView dataGridViewDados;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button tabelaVenda;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlivro;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn preco;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataAdicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn siatuacao;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.PictureBox imgAddCarrinho;
        private System.Windows.Forms.PictureBox imgVerCarrinho;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}