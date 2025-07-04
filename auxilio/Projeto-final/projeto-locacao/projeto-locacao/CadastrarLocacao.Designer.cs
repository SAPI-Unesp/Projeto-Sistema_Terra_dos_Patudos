namespace projeto_locacao
{
    partial class CadastrarLocacao
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Preco = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Data_inicio = new System.Windows.Forms.TextBox();
            this.Data_fim = new System.Windows.Forms.TextBox();
            this.IdCliente = new System.Windows.Forms.TextBox();
            this.IdFuncionario = new System.Windows.Forms.TextBox();
            this.IdLivro = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Início";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Fim";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "ID Funcionário";
            // 
            // Preco
            // 
            this.Preco.AutoSize = true;
            this.Preco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Preco.Location = new System.Drawing.Point(26, 332);
            this.Preco.Name = "Preco";
            this.Preco.Size = new System.Drawing.Size(43, 16);
            this.Preco.TabIndex = 4;
            this.Preco.Text = "Preço";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "ID Livro";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(323, 31);
            this.label7.TabIndex = 6;
            this.label7.Text = "CADASTRAR LOCAÇÃO";
            // 
            // Data_inicio
            // 
            this.Data_inicio.Enabled = false;
            this.Data_inicio.Location = new System.Drawing.Point(109, 82);
            this.Data_inicio.Name = "Data_inicio";
            this.Data_inicio.Size = new System.Drawing.Size(237, 20);
            this.Data_inicio.TabIndex = 7;
            // 
            // Data_fim
            // 
            this.Data_fim.Enabled = false;
            this.Data_fim.Location = new System.Drawing.Point(109, 128);
            this.Data_fim.Name = "Data_fim";
            this.Data_fim.Size = new System.Drawing.Size(237, 20);
            this.Data_fim.TabIndex = 8;
            // 
            // IdCliente
            // 
            this.IdCliente.Location = new System.Drawing.Point(109, 178);
            this.IdCliente.Name = "IdCliente";
            this.IdCliente.Size = new System.Drawing.Size(237, 20);
            this.IdCliente.TabIndex = 9;
            // 
            // IdFuncionario
            // 
            this.IdFuncionario.Enabled = false;
            this.IdFuncionario.Location = new System.Drawing.Point(109, 227);
            this.IdFuncionario.Name = "IdFuncionario";
            this.IdFuncionario.Size = new System.Drawing.Size(237, 20);
            this.IdFuncionario.TabIndex = 10;
            // 
            // IdLivro
            // 
            this.IdLivro.Location = new System.Drawing.Point(109, 275);
            this.IdLivro.Name = "IdLivro";
            this.IdLivro.Size = new System.Drawing.Size(237, 20);
            this.IdLivro.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(317, 36);
            this.button1.TabIndex = 13;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(255, 329);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Gerar Preço";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(271, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Voltar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CadastarLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 437);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IdLivro);
            this.Controls.Add(this.IdFuncionario);
            this.Controls.Add(this.IdCliente);
            this.Controls.Add(this.Data_fim);
            this.Controls.Add(this.Data_inicio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Preco);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CadastarLocacao";
            this.Text = "CadastarLocacao";
            this.Load += new System.EventHandler(this.CadastarLocacao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Preco;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Data_inicio;
        private System.Windows.Forms.TextBox Data_fim;
        private System.Windows.Forms.TextBox IdCliente;
        private System.Windows.Forms.TextBox IdFuncionario;
        private System.Windows.Forms.TextBox IdLivro;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}