using ApiVentas.ApiRest.Services.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Managers.DTO
{
    public class PedidoListaDTO
    {
        public int Codigo { get; set; }
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }


        public PedidoListaDTO()
        {

        }

        public PedidoListaDTO(Pedido pedido)
        {
            Codigo = pedido.IdPedido;
            NombreCliente = pedido.Cliente.NombreCliente;
            Fecha = pedido.FechaPedido;
        }
    }
}
