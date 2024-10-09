
namespace CadastroBanco
{
    partial class FormTabelaVenda
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
            this.cbPessoas = new System.Windows.Forms.ComboBox();
            this.dataPickerStart = new System.Windows.Forms.DateTimePicker();
            this.dataPickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.cbPagamento = new System.Windows.Forms.ComboBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataAdicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comprador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDados)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDados
            // 
            this.dataGridViewDados.AllowUserToAddRows = false;
            this.dataGridViewDados.AllowUserToDeleteRows = false;
            this.dataGridViewDados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewDados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewDados.ColumnHeadersHeight = 40;
            this.dataGridViewDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.categoria,
            this.descricao,
            this.quantidade,
            this.preco,
            this.dataAdicao,
            this.comprador,
            this.telefone,
            this.vendido});
            this.dataGridViewDados.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewDados.Name = "dataGridViewDados";
            this.dataGridViewDados.Size = new System.Drawing.Size(892, 622);
            this.dataGridViewDados.TabIndex = 10;
            this.dataGridViewDados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDados_CellContentClick);
            // 
            // cbPessoas
            // 
            this.cbPessoas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPessoas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPessoas.FormattingEnabled = true;
            this.cbPessoas.Location = new System.Drawing.Point(956, 48);
            this.cbPessoas.Name = "cbPessoas";
            this.cbPessoas.Size = new System.Drawing.Size(121, 28);
            this.cbPessoas.TabIndex = 12;
            this.cbPessoas.SelectedIndexChanged += new System.EventHandler(this.cbPessoas_SelectedIndexChanged);
            // 
            // dataPickerStart
            // 
            this.dataPickerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPickerStart.Location = new System.Drawing.Point(956, 122);
            this.dataPickerStart.Name = "dataPickerStart";
            this.dataPickerStart.Size = new System.Drawing.Size(200, 26);
            this.dataPickerStart.TabIndex = 13;
            this.dataPickerStart.ValueChanged += new System.EventHandler(this.dataPickerStart_ValueChanged);
            // 
            // dataPickerEnd
            // 
            this.dataPickerEnd.Checked = false;
            this.dataPickerEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPickerEnd.Location = new System.Drawing.Point(956, 158);
            this.dataPickerEnd.Name = "dataPickerEnd";
            this.dataPickerEnd.Size = new System.Drawing.Size(200, 26);
            this.dataPickerEnd.TabIndex = 14;
            this.dataPickerEnd.Value = new System.DateTime(2024, 10, 10, 0, 0, 0, 0);
            this.dataPickerEnd.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(966, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Valor Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(959, 391);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(183, 31);
            this.txtTotal.TabIndex = 16;
            // 
            // cbPagamento
            // 
            this.cbPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPagamento.FormattingEnabled = true;
            this.cbPagamento.Items.AddRange(new object[] {
            "Realizado",
            "não pagou",
            "verificar"});
            this.cbPagamento.Location = new System.Drawing.Point(1102, 48);
            this.cbPagamento.Name = "cbPagamento";
            this.cbPagamento.Size = new System.Drawing.Size(121, 28);
            this.cbPagamento.TabIndex = 17;
            this.cbPagamento.SelectedIndexChanged += new System.EventHandler(this.cbPagamento_SelectedIndexChanged);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.FillWeight = 64.70626F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // categoria
            // 
            this.categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.categoria.FillWeight = 86.86478F;
            this.categoria.HeaderText = "Categoria";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.FillWeight = 177.0492F;
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // quantidade
            // 
            this.quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.quantidade.FillWeight = 86.86478F;
            this.quantidade.HeaderText = "Quantidade Vendida";
            this.quantidade.Name = "quantidade";
            this.quantidade.ReadOnly = true;
            // 
            // preco
            // 
            this.preco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.preco.FillWeight = 86.86478F;
            this.preco.HeaderText = "Lucro";
            this.preco.Name = "preco";
            this.preco.ReadOnly = true;
            // 
            // dataAdicao
            // 
            this.dataAdicao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataAdicao.FillWeight = 86.86478F;
            this.dataAdicao.HeaderText = "Data da Venda";
            this.dataAdicao.Name = "dataAdicao";
            this.dataAdicao.ReadOnly = true;
            // 
            // comprador
            // 
            this.comprador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.comprador.FillWeight = 86.86478F;
            this.comprador.HeaderText = "Nome do Comprador";
            this.comprador.Name = "comprador";
            this.comprador.ReadOnly = true;
            // 
            // telefone
            // 
            this.telefone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.telefone.FillWeight = 86.86478F;
            this.telefone.HeaderText = "Telefone do Comprador";
            this.telefone.Name = "telefone";
            this.telefone.ReadOnly = true;
            // 
            // vendido
            // 
            this.vendido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.vendido.FillWeight = 137.0558F;
            this.vendido.HeaderText = "Pagamento";
            this.vendido.Name = "vendido";
            // 
            // FormTabelaVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 687);
            this.Controls.Add(this.cbPagamento);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataPickerEnd);
            this.Controls.Add(this.dataPickerStart);
            this.Controls.Add(this.cbPessoas);
            this.Controls.Add(this.dataGridViewDados);
            this.Name = "FormTabelaVenda";
            this.Text = "FormTabelaVenda";
            this.Load += new System.EventHandler(this.FormTabelaVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDados;
        private System.Windows.Forms.ComboBox cbPessoas;
        private System.Windows.Forms.DateTimePicker dataPickerStart;
        private System.Windows.Forms.DateTimePicker dataPickerEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.ComboBox cbPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn preco;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataAdicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn comprador;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendido;
    }
}