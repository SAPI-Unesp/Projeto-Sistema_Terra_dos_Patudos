namespace projeto_locacao
{
    partial class ProcurarLocacao
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
            this.label5 = new System.Windows.Forms.Label();
            this.Titulo = new System.Windows.Forms.TextBox();
            this.Data_inicio = new System.Windows.Forms.TextBox();
            this.Data_fim = new System.Windows.Forms.TextBox();
            this.Funcionario_At = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.IdLocacaoT = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Locação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome do Livro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Funcionário Atendente";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data de Início";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Data Fim";
            // 
            // Titulo
            // 
            this.Titulo.Enabled = false;
            this.Titulo.Location = new System.Drawing.Point(27, 112);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(143, 20);
            this.Titulo.TabIndex = 6;
            // 
            // Data_inicio
            // 
            this.Data_inicio.Enabled = false;
            this.Data_inicio.Location = new System.Drawing.Point(27, 171);
            this.Data_inicio.Name = "Data_inicio";
            this.Data_inicio.Size = new System.Drawing.Size(143, 20);
            this.Data_inicio.TabIndex = 7;
            // 
            // Data_fim
            // 
            this.Data_fim.Enabled = false;
            this.Data_fim.Location = new System.Drawing.Point(27, 235);
            this.Data_fim.Name = "Data_fim";
            this.Data_fim.Size = new System.Drawing.Size(143, 20);
            this.Data_fim.TabIndex = 8;
            // 
            // Funcionario_At
            // 
            this.Funcionario_At.Enabled = false;
            this.Funcionario_At.Location = new System.Drawing.Point(27, 294);
            this.Funcionario_At.Name = "Funcionario_At";
            this.Funcionario_At.Size = new System.Drawing.Size(143, 20);
            this.Funcionario_At.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 81);
            this.button1.TabIndex = 11;
            this.button1.Text = "Terminar Pesquisa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IdLocacaoT
            // 
            this.IdLocacaoT.AutoSize = true;
            this.IdLocacaoT.Location = new System.Drawing.Point(138, 36);
            this.IdLocacaoT.Name = "IdLocacaoT";
            this.IdLocacaoT.Size = new System.Drawing.Size(55, 13);
            this.IdLocacaoT.TabIndex = 37;
            this.IdLocacaoT.Text = "(CÓDIGO)";
            // 
            // ProcurarLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 346);
            this.Controls.Add(this.IdLocacaoT);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Funcionario_At);
            this.Controls.Add(this.Data_fim);
            this.Controls.Add(this.Data_inicio);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProcurarLocacao";
            this.Text = "Procurar Locação";
            this.Load += new System.EventHandler(this.ProcurarLocacaoCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Titulo;
        private System.Windows.Forms.TextBox Data_inicio;
        private System.Windows.Forms.TextBox Data_fim;
        private System.Windows.Forms.TextBox Funcionario_At;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label IdLocacaoT;
    }
}