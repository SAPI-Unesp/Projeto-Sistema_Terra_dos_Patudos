namespace CadastroBanco
{
    partial class FormVender
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
            this.QtdEstoque = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVender = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NomeText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TelText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.precoProd = new System.Windows.Forms.TextBox();
            this.precoTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.qtdVenda = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbRealizado = new System.Windows.Forms.CheckBox();
            this.cbNaoRealizado = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.qtdVenda)).BeginInit();
            this.SuspendLayout();
            // 
            // QtdEstoque
            // 
            this.QtdEstoque.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.QtdEstoque.Location = new System.Drawing.Point(12, 26);
            this.QtdEstoque.Name = "QtdEstoque";
            this.QtdEstoque.ReadOnly = true;
            this.QtdEstoque.Size = new System.Drawing.Size(100, 20);
            this.QtdEstoque.TabIndex = 1;
            this.QtdEstoque.TextChanged += new System.EventHandler(this.Qt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quantidade vendida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quantidade no estoque";
            // 
            // btnVender
            // 
            this.btnVender.Location = new System.Drawing.Point(371, 312);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(75, 23);
            this.btnVender.TabIndex = 4;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nome do cliente";
            // 
            // NomeText
            // 
            this.NomeText.Location = new System.Drawing.Point(12, 136);
            this.NomeText.Name = "NomeText";
            this.NomeText.Size = new System.Drawing.Size(100, 20);
            this.NomeText.TabIndex = 6;
            this.NomeText.TextChanged += new System.EventHandler(this.NomeText_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Telefone do cliente";
            // 
            // TelText
            // 
            this.TelText.Location = new System.Drawing.Point(12, 191);
            this.TelText.Name = "TelText";
            this.TelText.Size = new System.Drawing.Size(100, 20);
            this.TelText.TabIndex = 8;
            this.TelText.TextChanged += new System.EventHandler(this.TelText_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Preço unitario";
            // 
            // precoProd
            // 
            this.precoProd.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.precoProd.Location = new System.Drawing.Point(158, 26);
            this.precoProd.Name = "precoProd";
            this.precoProd.ReadOnly = true;
            this.precoProd.Size = new System.Drawing.Size(100, 20);
            this.precoProd.TabIndex = 10;
            // 
            // precoTotal
            // 
            this.precoTotal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.precoTotal.Location = new System.Drawing.Point(158, 78);
            this.precoTotal.Name = "precoTotal";
            this.precoTotal.ReadOnly = true;
            this.precoTotal.Size = new System.Drawing.Size(100, 20);
            this.precoTotal.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Preço Total";
            // 
            // qtdVenda
            // 
            this.qtdVenda.Location = new System.Drawing.Point(12, 78);
            this.qtdVenda.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.qtdVenda.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.qtdVenda.Name = "qtdVenda";
            this.qtdVenda.Size = new System.Drawing.Size(100, 20);
            this.qtdVenda.TabIndex = 13;
            this.qtdVenda.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.qtdVenda.ValueChanged += new System.EventHandler(this.qtdVenda_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Pagamento";
            // 
            // cbRealizado
            // 
            this.cbRealizado.AutoSize = true;
            this.cbRealizado.Checked = true;
            this.cbRealizado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRealizado.Location = new System.Drawing.Point(158, 138);
            this.cbRealizado.Name = "cbRealizado";
            this.cbRealizado.Size = new System.Drawing.Size(73, 17);
            this.cbRealizado.TabIndex = 15;
            this.cbRealizado.Text = "Realizado";
            this.cbRealizado.UseVisualStyleBackColor = true;
            this.cbRealizado.CheckedChanged += new System.EventHandler(this.cbRealizado_CheckedChanged);
            // 
            // cbNaoRealizado
            // 
            this.cbNaoRealizado.AutoSize = true;
            this.cbNaoRealizado.Location = new System.Drawing.Point(244, 139);
            this.cbNaoRealizado.Name = "cbNaoRealizado";
            this.cbNaoRealizado.Size = new System.Drawing.Size(72, 17);
            this.cbNaoRealizado.TabIndex = 16;
            this.cbNaoRealizado.Text = "Pendente";
            this.cbNaoRealizado.UseVisualStyleBackColor = true;
            this.cbNaoRealizado.CheckedChanged += new System.EventHandler(this.cbNaoRealizado_CheckedChanged);
            // 
            // FormVender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 347);
            this.Controls.Add(this.cbNaoRealizado);
            this.Controls.Add(this.cbRealizado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.qtdVenda);
            this.Controls.Add(this.precoTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.precoProd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TelText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NomeText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QtdEstoque);
            this.Name = "FormVender";
            this.Text = "Venda";
            this.Load += new System.EventHandler(this.FormVender_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qtdVenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox QtdEstoque;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NomeText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TelText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox precoProd;
        private System.Windows.Forms.TextBox precoTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown qtdVenda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbRealizado;
        private System.Windows.Forms.CheckBox cbNaoRealizado;
    }
}