using ApiVentas.ApiRest.Managers.DTO;
using ApiVentas.ApiRest.Services.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.OpServices
{
    public interface IArticuloOpService
    {
        List<Articulo> List();
        Articulo Get(int id);
        List<Articulo> ListPage(ProductoListaPaginadaParamDTO param);
        Articulo Save(Articulo articulo);
        ArticuloImagen SaveImage(ArticuloImagen articuloImagen);

        Task<int> Delete(int IdArticulo);
    }
}
