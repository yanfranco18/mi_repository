using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Managers.DTO
{
    public class LoginRequestDTO
    {
        public string Credencial { get; set; }
        public string Clave { get; set; }
    }
}
