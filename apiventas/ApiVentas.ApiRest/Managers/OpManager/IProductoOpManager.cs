using ApiVentas.ApiRest.Managers.DTO;
using ApiVentas.ApiRest.Services.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Managers.OpManager
{
    public interface IProductoOpManager
    {
        ProductoDTO Save(ProductoInsertParamDTO producto);
        ProductoDTO Update(ProductoUpdateParamDTO producto);
        ProductoDTO Get(int id);
        ProductoListaPaginadaDTO ListPage(ProductoListaPaginadaParamDTO param);
        List<ProductoDTO> List();

        ProductoImagenResponseDTO UploadImage(ProductoImagenParamDTO param);

        Task<int> Delete(int id);
    }
}
