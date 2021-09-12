using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Managers.DTO
{
    public class UserDTO
    {
        public int Codigo { get; set; }
        public string Credencial { get; set; }
        public string Rol { get; set; }
    }
}
