namespace projeto_locacao
{
    partial class EditarLivro
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
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Editora = new System.Windows.Forms.TextBox();
            this.Titulo = new System.Windows.Forms.TextBox();
            this.Fk_idFuncionario = new System.Windows.Forms.TextBox();
            this.Data_chegada = new System.Windows.Forms.TextBox();
            this.Estatus = new System.Windows.Forms.TextBox();
            this.Autor = new System.Windows.Forms.TextBox();
            this.IdLivro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Qtd_paginas = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Valor_locacao = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 68);
            this.button1.TabIndex = 31;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 25);
            this.label8.TabIndex = 30;
            this.label8.Text = "EDITAR DADOS LIVRO";
            // 
            // Editora
            // 
            this.Editora.Location = new System.Drawing.Point(245, 260);
            this.Editora.Name = "Editora";
            this.Editora.Size = new System.Drawing.Size(230, 20);
            this.Editora.TabIndex = 29;
            // 
            // Titulo
            // 
            this.Titulo.Location = new System.Drawing.Point(245, 189);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(230, 20);
            this.Titulo.TabIndex = 28;
            // 
            // Fk_idFuncionario
            // 
            this.Fk_idFuncionario.Enabled = false;
            this.Fk_idFuncionario.Location = new System.Drawing.Point(245, 112);
            this.Fk_idFuncionario.Name = "Fk_idFuncionario";
            this.Fk_idFuncionario.Size = new System.Drawing.Size(230, 20);
            this.Fk_idFuncionario.TabIndex = 27;
            // 
            // Data_chegada
            // 
            this.Data_chegada.Location = new System.Drawing.Point(26, 336);
            this.Data_chegada.Name = "Data_chegada";
            this.Data_chegada.Size = new System.Drawing.Size(196, 20);
            this.Data_chegada.TabIndex = 26;
            // 
            // Estatus
            // 
            this.Estatus.Enabled = false;
            this.Estatus.Location = new System.Drawing.Point(26, 260);
            this.Estatus.Name = "Estatus";
            this.Estatus.Size = new System.Drawing.Size(196, 20);
            this.Estatus.TabIndex = 25;
            // 
            // Autor
            // 
            this.Autor.Location = new System.Drawing.Point(26, 189);
            this.Autor.Name = "Autor";
            this.Autor.Size = new System.Drawing.Size(196, 20);
            this.Autor.TabIndex = 24;
            // 
            // IdLivro
            // 
            this.IdLivro.Enabled = false;
            this.IdLivro.Location = new System.Drawing.Point(26, 112);
            this.IdLivro.Name = "IdLivro";
            this.IdLivro.Size = new System.Drawing.Size(196, 20);
            this.IdLivro.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Data de Chegada";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Título";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Editora";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Funcionário que cadastrou o livro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Autor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "ID Livro";
            // 
            // Qtd_paginas
            // 
            this.Qtd_paginas.Location = new System.Drawing.Point(244, 336);
            this.Qtd_paginas.Name = "Qtd_paginas";
            this.Qtd_paginas.Size = new System.Drawing.Size(230, 20);
            this.Qtd_paginas.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(242, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Quantidade de Páginas";
            // 
            // Valor_locacao
            // 
            this.Valor_locacao.Location = new System.Drawing.Point(28, 413);
            this.Valor_locacao.Name = "Valor_locacao";
            this.Valor_locacao.Size = new System.Drawing.Size(194, 20);
            this.Valor_locacao.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 397);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Valor da Locação";
            // 
            // EditarLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 476);
            this.Controls.Add(this.Valor_locacao);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Qtd_paginas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Editora);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.Fk_idFuncionario);
            this.Controls.Add(this.Data_chegada);
            this.Controls.Add(this.Estatus);
            this.Controls.Add(this.Autor);
            this.Controls.Add(this.IdLivro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditarLivro";
            this.Text = "EditarLivro";
            this.Load += new System.EventHandler(this.EditarLivro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Editora;
        private System.Windows.Forms.TextBox Titulo;
        private System.Windows.Forms.TextBox Fk_idFuncionario;
        private System.Windows.Forms.TextBox Data_chegada;
        private System.Windows.Forms.TextBox Estatus;
        private System.Windows.Forms.TextBox Autor;
        private System.Windows.Forms.TextBox IdLivro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Qtd_paginas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Valor_locacao;
        private System.Windows.Forms.Label label10;
    }
}