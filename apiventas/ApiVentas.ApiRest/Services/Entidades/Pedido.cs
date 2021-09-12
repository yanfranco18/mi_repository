using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.Entidades
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public int IdCliente { get; set; }
        public int Total { get; set; }


        public virtual Cliente Cliente { get; set; }
    }
}
