using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.Entidades
{
    public class ArticuloImagen
    {
        public int IdArticuloImagen { get; set; }
        public int IdArticulo { get; set; }
        
        public string NombreArchivo { get; set; }
        public string NombreGenerado { get; set; }

        public virtual Articulo Articulo { get; set; }
    }
}
