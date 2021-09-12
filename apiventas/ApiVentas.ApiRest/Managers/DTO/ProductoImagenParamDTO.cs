using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Managers.DTO
{
    public class ProductoImagenParamDTO
    {
        public IFormFile File { get; set; }
        public int Codigo { get; set; }
    }
}
