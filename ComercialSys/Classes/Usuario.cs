using System;
using System.Collections.Generic;
using System.Text;

namespace ComercialSys.Classes
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nivel { get; set; }
        public Usuario() { }

        public Usuario(int id, string nome, string email, string senha, string nivel)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Nivel = nivel;
        }

        public Usuario(string nome, string email, string senha, string nivel)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Nivel = nivel;
        }

        public void Inserir()
        {
            // conectar ao banco
            var cmd = Banco.Abrir();
            // inserir valores na tabela 
            cmd.CommandText = "insert usuarios values (0, '" + Nome + "', '" + Email + "', default, md5('" + Senha + "'), '" + Nivel + "');";
            cmd.ExecuteNonQuery();
            // atribuir id a Propriedade Id
            cmd.CommandText = "select @@identity";
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            // fecha a concexao
        }

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            // conectar ao banco
            var cmd = Banco.Abrir();
            cmd.CommandText = "select * from usuarios";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Usuario(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetString(3),
                    dr.GetString(4)
                ));
            }
            return lista;
        }

        public void BuscarPorId(int id)
        {
            var cmd = Banco.Abrir();
            // buscar o registro na tabela
            cmd.CommandText = "select * from usuarios where id = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                Email = dr.GetString(2);
                Senha = dr.GetString(3);
                Nivel = dr.GetString(4);
            }
        }

        public bool Alterar(int id)
        {
            bool alterado = false;
            // conectar ao banco 
            var cmd = Banco.Abrir();
            // buscar o registro na tabela a ser alterado
            // atribuir os valores as propriedades
            cmd.CommandText = "update usuarios " +
                "set nome = '" + Nome + "'," +
                "email = '" + Email + "'," +
                "senha = md5('" + Senha + "')" +
                "nivel = '" + Nivel + "'," +
                "where id = "+id;
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
            return alterado;
        }
    }
}
