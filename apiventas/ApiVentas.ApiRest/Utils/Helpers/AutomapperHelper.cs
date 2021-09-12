using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVentas.ApiRest.Managers.DTO;
using ApiVentas.ApiRest.Services.Entidades;
using AutoMapper;

namespace ApiVentas.ApiRest.Utils.Helpers
{
    public class AutomapperHelper : Profile
    {
        public AutomapperHelper()
        {
            CreateMap<Pedido, PedidoListaDTO>()
                .ForMember(t => t.Codigo, opt => opt.MapFrom(o => o.IdPedido))
                .ForMember(t => t.Fecha, opt => opt.MapFrom(o => o.FechaPedido))
                .ForMember(t => t.NombreCliente,
                            opt => opt.MapFrom(o => o.Cliente.NombreCliente))
                .ReverseMap()
                ;

            CreateMap<ProductoDTO, Articulo>()
              .ForMember(t => t.IdArticulo, opt => opt.MapFrom(o => o.Codigo))
              .ForMember(t => t.Nombre, opt => opt.MapFrom(o => o.Nombre))
              .ForMember(t => t.Precio, opt => opt.MapFrom(o => o.Precio))
              .ForMember(t => t.ArticuloImagen, opt => opt.MapFrom(o => o.ProductoImagenDTO))
              .ReverseMap()
              ;

            CreateMap<ProductoInsertParamDTO, Articulo>()
           .ForMember(t => t.Nombre, opt => opt.MapFrom(o => o.Nombre))
           .ForMember(t => t.Precio, opt => opt.MapFrom(o => o.Precio))
           .ReverseMap()
           ;

            CreateMap<ProductoUpdateParamDTO, Articulo>()
            .ForMember(t => t.IdArticulo, opt => opt.MapFrom(o => o.Codigo))
            .ForMember(t => t.Nombre, opt => opt.MapFrom(o => o.Nombre))
            .ForMember(t => t.Precio, opt => opt.MapFrom(o => o.Precio))
            .ReverseMap()
            ;

            CreateMap<ProductoImagenDTO, ArticuloImagen>()
          .ForMember(t => t.IdArticuloImagen, opt => opt.MapFrom(o => o.Codigo))
          .ForMember(t => t.NombreArchivo, opt => opt.MapFrom(o => o.Url))
          .ReverseMap()
          ;

            CreateMap<UserDTO, Usuario>()
            .ForMember(t => t.IdUsuario, opt => opt.MapFrom(o => o.Codigo))
            .ForMember(t => t.Credencial, opt => opt.MapFrom(o => o.Credencial))
            .ForMember(t => t.Rol, opt => opt.MapFrom(o => o.Rol))
            .ReverseMap()
            ;

            CreateMap<OpcionDTO, Opcion>()
            .ForMember(t => t.IdOpcion, opt => opt.MapFrom(o => o.Codigo))
            .ForMember(t => t.Icono, opt => opt.MapFrom(o => o.Icono))
            .ForMember(t => t.Nombre, opt => opt.MapFrom(o => o.Nombre))
            .ForMember(t => t.Url, opt => opt.MapFrom(o => o.Ruta))
            .ReverseMap()
            ;
        }

    }
}
