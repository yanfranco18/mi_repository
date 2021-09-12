using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Managers.DTO
{
    public class ProductoInsertParamDTO
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
