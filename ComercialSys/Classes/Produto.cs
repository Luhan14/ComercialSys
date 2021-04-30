using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercialSys.Classes
{
    public class Produto
    {
        // atributos
        // propriedades
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string CodBar { get; set; }
        public double Valor { get; set; }
        public double Desconto { get; set; }
        // métodos construtores
        public Produto() { }

        public Produto(int id, string descricao, string codBar, double valor, double desconto)
        {
            Id = id;
            Descricao = descricao;
            CodBar = codBar;
            Valor = valor;
            Desconto = desconto;
        }
        public Produto(string descricao, string codBar, double valor, double desconto)
        {
            Descricao = descricao;
            CodBar = codBar;
            Valor = valor;
            Desconto = desconto;
        }
        // métodos  - "funcionalidades"
        public void Inserir()
        {
            // conectar ao banco
            var cmd = Banco.Abrir();
            // inserir valores na tabela 
            cmd.CommandText = "insert produtos values (0, '" + Descricao + "', '" + CodBar + "', '" + Valor + "', '" + Desconto + "');";
            cmd.ExecuteNonQuery();
            // atribuir id a Propriedade Id
            cmd.CommandText = "select @@identity";
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            // fecha a concexao
        }
        public List<Produto> Listar() // lista todos os produtos
        {
            List<Produto> lista = new List<Produto>();
            // conectar ao banco
            var cmd = Banco.Abrir();
            cmd.CommandText = "select * from clientes";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Produto(
                   dr.GetInt32(0),
                   dr.GetString(1),
                   dr.GetString(2),
                   dr.GetInt32(3),
                   dr.GetInt32(4)
                ));
            }
            // buscar registros na tabela 
            // atribuir registros à lista
            // fecha a concexao
            // entregar lista pra quem chamou
            return lista;
        }
        public void BuscarPorId(int id) // lista todos os produtos
        {
            // conectar ao banco
            var cmd = Banco.Abrir();
            // buscar o registro na tabela  
            cmd.CommandText = "select * from produtos where id = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Descricao = dr.GetString(1);
                CodBar = dr.GetString(2);
                Valor = dr.GetInt32(3);
                Desconto= dr.GetInt32(4);
            }
            // atribuir os valores às propriedades
            // fecha a concexao
        }
        public bool Alterar(int id)
        {
            bool alterado = false;
            // conectar ao banco
            var cmd = Banco.Abrir();
            // buscar o registro na tabela  a ser alterado 
            // atribuir os valores às propriedades
         

            cmd.CommandText = "update produtos " +
                "set descricao = '" + Descricao + "'," +
                "cod_bar = '" + CodBar + "'," +
                "valor = '" + Valor + "'," +
                "desconto = ('" + Desconto + "')" +
                "where id = " + id;
            // registra a alteração
            try
            {
                cmd.ExecuteNonQuery();
                alterado = true;
            }
            catch (Exception)
            {
                throw;
            }
            // indica a validação (alterado com sucesso ou não)
            // fecha a concexao
            return alterado;
        }
    }
}