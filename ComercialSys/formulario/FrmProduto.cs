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
    public partial class FrmProduto : Form
    {
        public FrmProduto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.BuscarPorId(int.Parse(txtId.Text));
            txtDescricao.Text = produto.Descricao;
            txtCodBar.Text = produto.CodBar;
            txtValor.Text = produto.Valor.ToString();
            txtDesconto.Text = produto.Desconto.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Produto produto = new Produto();
            List<Produto> lista = produto.Listar();
            foreach (var registro in lista)
            {
                listBox1.Items.Add(registro.Descricao + " - " + registro.Valor);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            txtDescricao.Text = produto.Descricao;
            txtCodBar.Text = produto.CodBar;
            txtValor.Text = produto.Valor.ToString();
            txtDesconto.Text = produto.Desconto.ToString();
            produto.Inserir();
            txtId.Text = produto.Id.ToString();
            MessageBox.Show("Produto adicionado com êxito!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            txtDescricao.Text = produto.Descricao;
            txtCodBar.Text = produto.CodBar;
            txtValor.Text = produto.Valor.ToString();
            txtDesconto.Text = produto.Desconto.ToString();
            if (produto.Alterar(int.Parse(txtId.Text)))
            {
                MessageBox.Show("Produto alterado com Sucesso!");
            }
        }
    }

    }

