using ApiVentas.ApiRest.Services.Contexto;
using ApiVentas.ApiRest.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.OpServices
{
    public class PedidoOpService : IPedidoOpService
    {
        private readonly VentasContext context;

        public PedidoOpService(VentasContext context)
        {
            this.context = context;
        }

        public List<Pedido> List()
        {
            List<Pedido> lista = context.Pedido
                        .Include(t => t.Cliente).ToList();
            return lista;
        }
    }
}
