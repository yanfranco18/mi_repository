using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.Entidades
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public virtual List<ArticuloImagen> ArticuloImagen { get; set; }

    }
}
