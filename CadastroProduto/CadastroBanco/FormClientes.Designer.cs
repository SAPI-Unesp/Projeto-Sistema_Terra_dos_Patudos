namespace CadastroBanco
{
    partial class FormClientes
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
            this.btnEditar = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Divida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDados)).BeginInit();
            this.SuspendLayout();
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
            this.ID,
            this.Cliente,
            this.Telefone,
            this.Divida,
            this.Desconto,
            this.Credito});
            this.dataGridViewDados.Location = new System.Drawing.Point(12, 69);
            this.dataGridViewDados.MultiSelect = false;
            this.dataGridViewDados.Name = "dataGridViewDados";
            this.dataGridViewDados.ReadOnly = true;
            this.dataGridViewDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDados.Size = new System.Drawing.Size(509, 369);
            this.dataGridViewDados.TabIndex = 10;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Location = new System.Drawing.Point(615, 398);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 40);
            this.btnEditar.TabIndex = 18;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 40;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // Telefone
            // 
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            this.Telefone.ReadOnly = true;
            // 
            // Divida
            // 
            this.Divida.HeaderText = "Dívida";
            this.Divida.Name = "Divida";
            this.Divida.ReadOnly = true;
            this.Divida.Width = 70;
            // 
            // Desconto
            // 
            this.Desconto.HeaderText = "Desconto";
            this.Desconto.Name = "Desconto";
            this.Desconto.ReadOnly = true;
            this.Desconto.Width = 70;
            // 
            // Credito
            // 
            this.Credito.HeaderText = "Crédito";
            this.Credito.Name = "Credito";
            this.Credito.ReadOnly = true;
            this.Credito.Width = 70;
            // 
            // FormClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 450);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dataGridViewDados);
            this.Name = "FormClientes";
            this.Text = "Tabela de Clientes";
            this.Load += new System.EventHandler(this.FormClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDados;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Divida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credito;
    }
}