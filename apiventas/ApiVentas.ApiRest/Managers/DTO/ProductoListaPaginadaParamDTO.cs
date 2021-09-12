using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Managers.DTO
{
    public class ProductoListaPaginadaParamDTO
    {
        public string Filtro { get; set; }
        public string Order { get; set; }
        public int NroPagina { get; set; }
        public int RegPagina { get; set; }
        public int TotalReg { get; set; }

    }
}
