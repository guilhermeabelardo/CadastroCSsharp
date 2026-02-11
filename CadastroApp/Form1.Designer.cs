namespace SeuProjeto
{
    partial class Form1
    {
       
        private System.ComponentModel.IContainer components = null;

        
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

   
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.dgvCadastros = new System.Windows.Forms.DataGridView();
            this.btnInserir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCadastros)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(57, 30);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(100, 20);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.Text = "NOME";
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            this.txtTexto.Enter += new System.EventHandler(this.txtTexto_Enter);
            this.txtTexto.Leave += new System.EventHandler(this.txtTexto_Leave);
            // 
            // txtIDADE
            // 
            this.txtNumero.Location = new System.Drawing.Point(174, 30);
            this.txtNumero.MaxLength = 3;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.Text = "IDADE";
            this.txtNumero.Enter += new System.EventHandler(this.txtNumero_Enter);
            this.txtNumero.Leave += new System.EventHandler(this.txtNumero_Leave);
            // 
            // btnExcluir
            // 
            this.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.btnExcluir.Location = new System.Drawing.Point(57, 98);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "EXCLUIR";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.btnAtualizar.Location = new System.Drawing.Point(57, 127);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 3;
            this.btnAtualizar.Text = "ATUALIZAR";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click_1);
            // 
            // dgvCadastros
            // 
            this.dgvCadastros.AllowUserToAddRows = false;
            this.dgvCadastros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCadastros.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvCadastros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCadastros.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCadastros.Location = new System.Drawing.Point(334, 30);
            this.dgvCadastros.MultiSelect = false;
            this.dgvCadastros.Name = "dgvCadastros";
            this.dgvCadastros.ReadOnly = true;
            this.dgvCadastros.RowHeadersVisible = false;
            this.dgvCadastros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCadastros.Size = new System.Drawing.Size(257, 390);
            this.dgvCadastros.TabIndex = 4;
            
            // 
            // btnInserir
            // 
            this.btnInserir.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.btnInserir.ForeColor = System.Drawing.Color.Black;
            this.btnInserir.Location = new System.Drawing.Point(57, 69);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 0;
            this.btnInserir.Text = "INSERIR";
            this.btnInserir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(407, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "REGISTROS ATUAIS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(612, 428);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dgvCadastros);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtTexto);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Cadastro";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCadastros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.DataGridView dgvCadastros;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Label label1;
    }
}

