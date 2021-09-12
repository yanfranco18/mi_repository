using ApiVentas.ApiRest.Services.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.OpServices
{
    public interface ISeguridadOpService
    {

        #region Usuario

        Task<Usuario> RecuperarPorCredenciales(string credencial, string clave);

        #endregion
        #region Opciones

        Task<List<Opcion>> ListOpcionesPerfil(string perfil);

        #endregion

    }
}
