using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.Entidades
{
    public class Opcion
    {
        [Key]
        public int IdOpcion { get; set; }
        public string Nombre { get; set; }
        public string Icono { get; set; }
        public string Url { get; set; }
        public bool EsAdmin { get; set; }
        public bool EsOperador { get; set; }
         
    }
}
