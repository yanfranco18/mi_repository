using ApiVentas.ApiRest.Managers.OpManager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Controllers
{
    [Route("[controller]/[action]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoOpManager pedidoOpManager;

        public PedidoController(IPedidoOpManager pedidoOpManager)
        {
            this.pedidoOpManager = pedidoOpManager;
        }

        [HttpGet]
        public IActionResult ListarRes() {

            return Ok(pedidoOpManager.ListaReporte());
        }
    }
}
