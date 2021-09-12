using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.Entidades
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Credencial { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
    }
}
