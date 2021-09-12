using ApiVentas.ApiRest.Managers.OpManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OpcionController : ControllerBase
    {
        private readonly ISeguridadOpManager seguridadOpManager;

        public OpcionController(ISeguridadOpManager seguridadOpManager)
        {
            this.seguridadOpManager = seguridadOpManager;
        }

        [HttpGet]
        public async Task<IActionResult> Listar() {

            string miRol = HttpContext.User.Claims.FirstOrDefault(t => t.Type == "rol")?.Value;

            return Ok(await seguridadOpManager.ListarPorRol(miRol));
        }
    }
}
