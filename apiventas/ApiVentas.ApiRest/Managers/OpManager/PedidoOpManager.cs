using ApiVentas.ApiRest.Managers.DTO;
using ApiVentas.ApiRest.Services.Entidades;
using ApiVentas.ApiRest.Services.OpServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace ApiVentas.ApiRest.Managers.OpManager
{
    public class PedidoOpManager : IPedidoOpManager
    {
        private readonly IPedidoOpService pedidoOpService;
        private readonly IMapper mapper;

        public PedidoOpManager(
            IPedidoOpService pedidoOpService, IMapper mapper)
        {
            this.pedidoOpService = pedidoOpService;
            this.mapper = mapper;
        }
        public List<PedidoListaDTO> ListaReporte()
        {
            List<Pedido> pedidos = pedidoOpService.List();

            //List<PedidoListaDTO> res = (from x in pedidos
            //            select new PedidoListaDTO(x)).ToList();

            List<PedidoListaDTO> res = mapper.Map<List<PedidoListaDTO>>(pedidos);

            return res;
        }
    }
}
