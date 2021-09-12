using ApiVentas.ApiRest.Managers.DTO;
using ApiVentas.ApiRest.Managers.OpManager;
using ApiVentas.ApiRest.Services.Entidades;
using ApiVentas.ApiRest.Services.OpServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class ArticuloController : ControllerBase
    {
        private readonly IProductoOpManager articuloOpManager;
        private readonly ILogger<ArticuloController> logger;

        public ArticuloController(
            IProductoOpManager articuloOpManager,
            ILogger<ArticuloController> logger
            )
        {
            this.articuloOpManager = articuloOpManager;
            this.logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Grabar([FromBody] ProductoInsertParamDTO producto) {

            logger.LogError("Esta llegando data errada");

            ProductoDTO res = articuloOpManager.Save(producto);
            return Ok(res);
        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] ProductoUpdateParamDTO producto)
        {

            logger.LogError("Esta llegando data errada");

            ProductoDTO res = articuloOpManager.Update(producto);
            return Ok(res);
        }

        //[AllowAnonymous]
        [HttpGet]
        public IActionResult Recuperar(int id)
        {

            ProductoDTO a = articuloOpManager.Get(id);
            if (a == null)
            {
                return BadRequest("El codigo no existe");
            }

            return Ok(a);
        }
       // [AllowAnonymous]
        [HttpGet]
        public IActionResult ListarPag(ProductoListaPaginadaParamDTO param)
        {

            return Ok(articuloOpManager.ListPage(param));
        }
        
        //[AllowAnonymous]
        [HttpGet]
        public IActionResult Listar()
        {

            return Ok(articuloOpManager.List());
        }

        [HttpPost()]
        //public IActionResult SubirImagen(IFormFile file, int codigo) {
        public IActionResult SubirImagen(ProductoImagenParamDTO param)
        {
            return Ok(articuloOpManager.UploadImage(param));
             
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id) {
            return Ok(await articuloOpManager.Delete(id));
        }
    }
}
