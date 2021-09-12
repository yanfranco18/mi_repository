using ApiVentas.ApiRest.Services.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.OpServices
{
    public interface IPedidoOpService
    {
        List<Pedido> List();
    }
}
