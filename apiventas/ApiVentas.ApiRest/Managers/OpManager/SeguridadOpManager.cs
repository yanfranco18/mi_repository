using ApiVentas.ApiRest.Managers.DTO;
using ApiVentas.ApiRest.Services.Entidades;
using ApiVentas.ApiRest.Services.OpServices;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Managers.OpManager
{
    public class SeguridadOpManager : ISeguridadOpManager
    {
        private readonly ISeguridadOpService seguridadOpService;
        private readonly IMapper mapper;

        public SeguridadOpManager(
            ISeguridadOpService seguridadOpService, IMapper mapper)
        {
            this.seguridadOpService = seguridadOpService;
            this.mapper = mapper;
        }
        public async Task<LoginResponseDTO> Autentica(LoginRequestDTO request)
        {
            LoginResponseDTO response = null;

            Usuario usuario = await seguridadOpService.RecuperarPorCredenciales(request.Credencial, request.Clave);
            UserDTO user = mapper.Map<UserDTO>(usuario);
            if (user == null)
            {
                return null;
            }
            //if (!(request.Credencial == "jperez" && request.Clave == "123456"))
            //{
            //    return null;
            //}

            //Generar la semilla
            string semilla = "Galaxy123abcdef007";
            byte[] semillarByte = Encoding.UTF8.GetBytes(semilla);
            SymmetricSecurityKey key = new SymmetricSecurityKey(semillarByte);

            //Crear el algoritmo de ofuscacion
            var encripta = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Crear el payload
            var misclaims = new[] {
                new Claim("cod", user.Codigo.ToString()),
                new Claim("usr", user.Credencial),
                new Claim("rol", user.Rol)
            };

            //Crear el generador de token
            JwtSecurityToken generador = new JwtSecurityToken(
                claims: misclaims,
                signingCredentials: encripta,
                expires: DateTime.Now.AddMinutes(5),
                issuer: "demo.com",
                audience: "demo.com"
                );

            //CRear un token basado en el generador
            string tk = new JwtSecurityTokenHandler().WriteToken(generador);

            response = new LoginResponseDTO
            {
                Token = tk,
                Codigo = user.Codigo
            };


            return response;
        }

        public async Task<List<OpcionDTO>> ListarPorRol(string rol)
        {
            List<Opcion> opciones = await seguridadOpService.ListOpcionesPerfil(rol);
            List<OpcionDTO> res = mapper.Map<List<OpcionDTO>>(opciones);
            return res;
        }
    }
}
