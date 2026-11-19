using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using System.Windows.Forms;

namespace _261170_261296.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string marca { get; set; }
        public double valorVenda { get; set; }
        public double estoque { get; set; }
        public string categoria { get; set; }
        public string foto { get; set; }


        public void Incluir()
        {
            try
            {
                Banco.Conexao.Open();
                Banco.Comando = new MySqlCommand
                ("INSERT INTO produtos (descricao, marca, valorVenda, estoque, categoria, foto) " +
                "VALUES (@descricao, @marca, @valorVenda, @estoque, @categoria, @foto)", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@descricao", descricao);
                Banco.Comando.Parameters.AddWithValue("@marca", marca);
                Banco.Comando.Parameters.AddWithValue("@valorVenda", valorVenda);
                Banco.Comando.Parameters.AddWithValue("@estoque", estoque);
                Banco.Comando.Parameters.AddWithValue("@categoria", categoria);
                Banco.Comando.Parameters.AddWithValue("@foto", foto);
                Banco.Comando.ExecuteNonQuery();
                Banco.Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Alterar()
        {
            try
            {
                Banco.Conexao.Open();
                Banco.Comando = new MySqlCommand
                ("UPDATE produtos SET descricao = @descricao, marca = @marca, valorVenda = @valorVenda, " +
                "estoque = @estoque, categoria = @categoria, foto = @foto, venda = @venda where id = @id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@descricao", descricao);
                Banco.Comando.Parameters.AddWithValue("@marca", marca);
                Banco.Comando.Parameters.AddWithValue("@valorVenda", valorVenda);
                Banco.Comando.Parameters.AddWithValue("@estoque", estoque);
                Banco.Comando.Parameters.AddWithValue("@categoria", categoria);
                Banco.Comando.Parameters.AddWithValue("@foto", foto);
                Banco.Comando.Parameters.AddWithValue("@id", id);
                Banco.Comando.ExecuteNonQuery();
                Banco.Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {
                Banco.Conexao.Open();
                Banco.Comando = new MySqlCommand("delete from produtos where id = @id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@id", id);
                Banco.Comando.ExecuteNonQuery();
                Banco.Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}