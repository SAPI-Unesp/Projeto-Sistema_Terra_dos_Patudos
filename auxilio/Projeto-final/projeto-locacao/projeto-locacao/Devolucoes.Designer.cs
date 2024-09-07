namespace projeto_locacao
{
    partial class Devolucoes
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
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Dia = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Ano = new System.Windows.Forms.TextBox();
            this.Mes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(38, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 26);
            this.button2.TabIndex = 19;
            this.button2.Text = "Voltar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(38, 146);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(609, 316);
            this.listBox1.TabIndex = 12;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "Devoluções";
            // 
            // Dia
            // 
            this.Dia.FormattingEnabled = true;
            this.Dia.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "-07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.Dia.Location = new System.Drawing.Point(312, 35);
            this.Dia.Name = "Dia";
            this.Dia.Size = new System.Drawing.Size(48, 21);
            this.Dia.TabIndex = 37;
            this.Dia.Text = "Dia";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(538, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 23);
            this.button3.TabIndex = 36;
            this.button3.Text = "Buscar por data";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Ano
            // 
            this.Ano.Location = new System.Drawing.Point(432, 35);
            this.Ano.Name = "Ano";
            this.Ano.Size = new System.Drawing.Size(100, 20);
            this.Ano.TabIndex = 35;
            this.Ano.Text = "Ano";
            // 
            // Mes
            // 
            this.Mes.FormattingEnabled = true;
            this.Mes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.Mes.Location = new System.Drawing.Point(366, 35);
            this.Mes.Name = "Mes";
            this.Mes.Size = new System.Drawing.Size(60, 21);
            this.Mes.TabIndex = 34;
            this.Mes.Text = "Mês";
            // 
            // Devolucoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 494);
            this.Controls.Add(this.Dia);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Ano);
            this.Controls.Add(this.Mes);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Name = "Devolucoes";
            this.Text = "Devoluções";
            this.Load += new System.EventHandler(this.Devolucoes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Dia;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox Ano;
        private System.Windows.Forms.ComboBox Mes;
    }
}