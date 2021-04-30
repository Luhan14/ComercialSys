using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComercialSys.Classes;

namespace ComercialSys.formulario
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.BuscarPorId(int.Parse(txtId.Text));
            txtNome.Text = usuario.Nome;
            txtEmail.Text = usuario.Email;
            txtSenha.Text = usuario.Senha;
            txtNivel.Text = usuario.Nivel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Usuario usuario = new Usuario();
            List<Usuario> lista = usuario.Listar();
            foreach (var registro in lista)
            {
                listBox1.Items.Add(registro.Nome + " - " + registro.Email);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = txtNome.Text;
            usuario.Email = txtEmail.Text;
            usuario.Senha = txtNivel.Text;
            usuario.Nivel = txtNivel.Text;
            usuario.Inserir();
            txtId.Text = usuario.Id.ToString();
            MessageBox.Show("Usuário inserido com sucesso!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = txtNome.Text;
            usuario.Email = txtEmail.Text;
            usuario.Senha = txtNivel.Text;
            usuario.Nivel = txtNivel.Text;
            if (usuario.Alterar(int.Parse(txtId.Text)))
            {
                MessageBox.Show("Usuário alterado com Sucesso!");
            }
        }
    }
}
