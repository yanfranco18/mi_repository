using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }

        public virtual List<Pedido> Pedidos { get; set; }
    }
}
