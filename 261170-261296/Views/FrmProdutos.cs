using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _261170_261296.Models;

namespace _261170_261296.Views
{
    public partial class FrmProdutos : Form
    {
        Produto pr;
        Categoria ca;
        Marca ma;

        public FrmProdutos()
        {
            InitializeComponent();
        }
        void LimpaControles()
        {
            txtCodigo.Clear();
            txtEstoque.Clear();
            cboMarca.SelectedIndex = -1; //-1 pq não tem nenhum item selecionado
            cboCategoria.SelectedIndex = -1;
            txtVenda.Clear();
            txtDescricao.Clear();
            picFoto.ImageLocation = "";
            txtPesquisa.Clear();
        }
        void carregarGrid(string pesquisa)
        {
            pr = new Produto()
            {
                descricao = pesquisa
            };

            DgvProdutos.DataSource = pr.Consultar();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            ma = new Marca();
            cboMarca.DataSource = ma.Consultar();
            cboMarca.DisplayMember = "marca";
            cboMarca.ValueMember = "id";

            ca = new Categoria();
            cboCategoria.DataSource = ca.Consultar();
            cboCategoria.DisplayMember = "categoria";
            cboCategoria.ValueMember = "id";

            LimpaControles();
            carregarGrid("");

            }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "") return;

            pr = new Produto()
            {
                descricao = txtDescricao.Text,
                marca = cboMarca.SelectedValue.ToString(),
                categoria = cboCategoria.SelectedValue.ToString(),
                estoque = int.Parse(txtEstoque.Text),
                valorVenda = double.Parse(txtVenda.Text),
                foto = picFoto.ImageLocation
            };

            pr.Incluir();

            LimpaControles();
            carregarGrid("");

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "") return;

            pr = new Produto()
            {
                id = int.Parse(txtCodigo.Text),
                descricao = txtDescricao.Text,
                marca = cboMarca.SelectedValue.ToString(),
                categoria = cboCategoria.SelectedValue.ToString(),
                estoque = double.Parse(txtEstoque.Text),
                valorVenda = double.Parse(txtVenda.Text),
                foto = picFoto.ImageLocation
            };

            pr.Alterar();

            LimpaControles();
            carregarGrid("");
        }

       

        private void DgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        
            if (DgvProdutos.RowCount > 0)
            {
                txtCodigo.Text = DgvProdutos.CurrentRow.Cells["id"].Value.ToString();
                txtDescricao.Text = DgvProdutos.CurrentRow.Cells["descricao"].Value.ToString();
                cboMarca.SelectedValue = DgvProdutos.CurrentRow.Cells["idMarca"].Value;
                cboCategoria.SelectedValue = DgvProdutos.CurrentRow.Cells["idCategoria"].Value;
                txtEstoque.Text = DgvProdutos.CurrentRow.Cells["estoque"].Value.ToString();
                txtVenda.Text = DgvProdutos.CurrentRow.Cells["valorVenda"].Value.ToString();
                picFoto.ImageLocation = DgvProdutos.CurrentRow.Cells["foto"].Value.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (DgvProdutos.CurrentRow == null) return;
            if (DgvProdutos.CurrentRow.IsNewRow) return;

            if (MessageBox.Show("Deseja excluir o produto?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pr = new Produto()
                {
                    id = int.Parse(DgvProdutos.CurrentRow.Cells["id"].Value.ToString())
                };

                pr.Excluir();

                LimpaControles();
                carregarGrid("");
            }

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

