using System;
using System.Collections.Generic;
using System.Text;

namespace ComercialSys.Classes
{
    class Pedido
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public Cliente Cliente { get; set; }

        public Usuario Usuario { get; set; }

        public double Desconto { get; set; }

        public string Situacao { get; set; }

        public List<Item> Items { get; set; }
    }
}
