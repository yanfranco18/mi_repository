using ApiVentas.ApiRest.Managers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Managers.OpManager
{
    public interface ISeguridadOpManager
    {
        Task<LoginResponseDTO> Autentica(LoginRequestDTO request);
        Task<List<OpcionDTO>> ListarPorRol(string rol);
    }
}
