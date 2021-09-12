using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Managers.DTO
{
    public class ProductoListaPaginadaDTO
    {
        public int TotalReg { get; set; }
        public List<ProductoDTO> Productos { get; set; }
    }
}
