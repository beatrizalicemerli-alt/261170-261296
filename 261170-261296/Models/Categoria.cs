using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace _261170_261296.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public string categoria { get; set; }
        
    
    public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("SELECT * FROM Categorias where categoria like @categoria " +
                    "order by categoria", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@categoria", categoria + "%");

                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();

                Banco.Adaptador.Fill(Banco.datTabela);

                Banco.FecharConexao();

                return Banco.datTabela;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}


