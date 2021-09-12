using ApiVentas.ApiRest.Services.Contexto;
using ApiVentas.ApiRest.Services.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ApiVentas.ApiRest.Services.OpServices
{
    public class SeguridadOpService : ISeguridadOpService
    {
        private readonly VentasContext context;

        public SeguridadOpService(VentasContext context)
        {
            this.context = context;
        }
        public async Task<List<Opcion>> ListOpcionesPerfil(string perfil)
        {
            //debe mejorarse para tener una tabla de perfiles 
            if (perfil == "admin")
            {
                return await (from x in context.Opcion
                              where x.EsAdmin
                              select x).ToListAsync();
            }
            else
            {
                return await (from x in context.Opcion
                              where x.EsOperador
                              select x).ToListAsync();
            }
        }

        public async Task<Usuario> RecuperarPorCredenciales(string credencial, string clave)
        {
            return await (from x in context.Usuario
                    where x.Credencial.ToUpper() == credencial.ToUpper()
                    && x.Clave == clave
                    select x).FirstOrDefaultAsync();
        }
    }
}
