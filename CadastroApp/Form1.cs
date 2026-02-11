using SeuProjeto.Data;
using System;
using System.Data; 
using System.Windows.Forms;
using System.Drawing;

namespace SeuProjeto
{
    public partial class Form1 : Form
    {
        private CadastroDAO dao = new CadastroDAO();
        private int IdRegistroSelecionado = -1; 

        public Form1()
        {
            InitializeComponent();
            CarregarDadosNaGrid();

            
            this.dgvCadastros.SelectionChanged += new EventHandler(this.dgvCadastros_SelectionChanged);

           
            this.btnInserir.Click += new EventHandler(this.btnInserir_Click);
            this.btnAtualizar.Click += new EventHandler(this.btnAtualizar_Click);
            this.btnExcluir.Click += new EventHandler(this.btnExcluir_Click);
        }

       
        private void LimparCampos()
        {
            txtTexto.Clear();
            txtNumero.Clear();
            IdRegistroSelecionado = -1;
        }

        private void CarregarDadosNaGrid()
        {
            try
            {
                DataTable dados = dao.ListarCadastros();
                dgvCadastros.DataSource = dados;

                
                if (dgvCadastros.Columns.Contains("id"))
                {
                    dgvCadastros.Columns["id"].Visible = false;
                }

                
                if (dgvCadastros.Columns.Contains("campo_texto"))
                {
                    dgvCadastros.Columns["campo_texto"].HeaderText = "NOME"; 
                }
                if (dgvCadastros.Columns.Contains("campo_numerico"))
                {
                    dgvCadastros.Columns["campo_numerico"].HeaderText = "IDADE"; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

       
        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTexto.Text) || txtTexto.Text == "NOME")
            {
                MessageBox.Show("Por favor, digite um nome válido.", "Atenção");
                return;
            }

            if (!int.TryParse(txtNumero.Text, out int numero))
            {
                MessageBox.Show("O campo numérico deve ser um número válido.", "Erro de Validação");
                return;
            }

            try
            {
                if (dao.InserirCadastro(txtTexto.Text, numero))
                {
                    MessageBox.Show("Registro inserido com sucesso!", "Sucesso");
                    CarregarDadosNaGrid();
                    LimparCampos();

                   
                    dgvCadastros.ClearSelection();
                    dgvCadastros.CurrentCell = null;
                    dgvCadastros.Focus();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("23505"))
                {
                    MessageBox.Show("Este número já está cadastrado!", "Número Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ex.Message.Contains("23514"))
                {
                    MessageBox.Show("O número deve ser maior que zero!", "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Erro ao salvar no banco: " + ex.Message, "Erro de Banco");
                }
            }
        }

        
        private void dgvCadastros_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dgvCadastros.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCadastros.SelectedRows[0];

                
                if (row.Cells["id"].Value != null &&
                    int.TryParse(row.Cells["id"].Value.ToString(), out int idValue))
                {
                    IdRegistroSelecionado = idValue;

                    
                    txtTexto.Text = row.Cells["campo_texto"].Value?.ToString() ?? string.Empty;
                    txtNumero.Text = row.Cells["campo_numerico"].Value?.ToString() ?? string.Empty;
                }
                else
                {
                    IdRegistroSelecionado = -1;
                }
            }
        }

        
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (IdRegistroSelecionado == -1)
            {
                MessageBox.Show("Selecione um registro na lista para atualizar.", "Atenção");
                return;
            }

            string novoTexto = txtTexto.Text;
            if (!int.TryParse(txtNumero.Text, out int novoNumero))
            {
                MessageBox.Show("O campo numérico deve ser um número inteiro válido.", "Atenção");
                return;
            }

            if (dao.AtualizarCadastro(IdRegistroSelecionado, novoTexto, novoNumero))
            {
                MessageBox.Show("Registro atualizado com sucesso!", "Sucesso");
                CarregarDadosNaGrid();
                LimparCampos();
            }
        }

        
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (IdRegistroSelecionado == -1)
            {
                MessageBox.Show("Selecione um registro na lista para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacao = MessageBox.Show($"Tem certeza que deseja excluir o ID {IdRegistroSelecionado}?",
                                                       "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                if (dao.ExcluirCadastro(IdRegistroSelecionado))
                {
                    MessageBox.Show("Registro excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarDadosNaGrid();
                    LimparCampos();
                }
            }

            
            CarregarDadosNaGrid();
            dgvCadastros.ClearSelection(); 
            dgvCadastros.CurrentCell = null; 
        }

        private void dgvCadastros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                
                dgvCadastros.Rows[e.RowIndex].Selected = true;

                var linha = dgvCadastros.Rows[e.RowIndex];
                txtTexto.Text = linha.Cells["campo_texto"].Value.ToString();
                txtNumero.Text = linha.Cells["campo_numerico"].Value.ToString();

                txtTexto.ForeColor = Color.Black;
                txtNumero.ForeColor = Color.Black;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Click_1(object sender, EventArgs e)
        {

        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        
        private void txtTexto_Enter(object sender, EventArgs e)
        {
            if (txtTexto.Text == "NOME")
            {
                txtTexto.Text = "";
                txtTexto.ForeColor = Color.Black;
            }
        }

        private void txtTexto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTexto.Text))
            {
                txtTexto.Text = "NOME";
                txtTexto.ForeColor = Color.Gray;
            }
        }

        
        private void txtNumero_Enter(object sender, EventArgs e)
        {
            if (txtNumero.Text == "IDADE")
            {
                txtNumero.Text = "";
                txtNumero.ForeColor = Color.Black;
            }
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                txtNumero.Text = "IDADE";
                txtNumero.ForeColor = Color.Gray;
            }
        }
    }
}


