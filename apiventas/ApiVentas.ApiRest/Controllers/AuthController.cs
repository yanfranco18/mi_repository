using ApiVentas.ApiRest.Managers.DTO;
using ApiVentas.ApiRest.Managers.OpManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISeguridadOpManager seguridadOpManager;

        public AuthController(ISeguridadOpManager seguridadOpManager)
        {
            this.seguridadOpManager = seguridadOpManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task< IActionResult> Valida(LoginRequestDTO request) {

            LoginResponseDTO resp = await seguridadOpManager.Autentica(request);
            if (resp == null)
            {
                return BadRequest("Usuario / clave no validos");
            }

            return Ok(resp);

        }

    }
}
