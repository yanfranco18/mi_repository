using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.Entidades
{
    public class PedidoArticulo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdPedidoArticulo { get; set; }
        public int IdPedido { get; set; }
        public int IdArticulo { get; set; }

        public int Cantidad { get; set; }

    }
}
