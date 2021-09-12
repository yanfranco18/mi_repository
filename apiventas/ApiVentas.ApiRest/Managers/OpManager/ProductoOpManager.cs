using ApiVentas.ApiRest.Managers.DTO;
using ApiVentas.ApiRest.Services.Entidades;
using ApiVentas.ApiRest.Services.OpServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Managers.OpManager
{
    public class ProductoOpManager : IProductoOpManager
    {
        private readonly IArticuloOpService articuloOpService;
        private readonly IMapper mapper;
        string ruta = @"D:\Imagenes";
        public ProductoOpManager(
            IArticuloOpService articuloOpService, IMapper mapper)
        {
            this.articuloOpService = articuloOpService;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            int res = await articuloOpService.Delete(id);
            return res;
        }

        public ProductoDTO Get(int id)
        {
            ProductoDTO res = null;
            Articulo a = articuloOpService.Get(id);
            if (a != null)
            {
                res = mapper.Map<ProductoDTO>(a);
            }
            return res;
        }

        public List<ProductoDTO> List()
        {
            List<Articulo> tmp = articuloOpService.List();
            List<ProductoDTO> res = mapper.Map<List<ProductoDTO>>(tmp);

            return res;
        }

        public ProductoListaPaginadaDTO ListPage(ProductoListaPaginadaParamDTO param)
        {
            List<Articulo> tmp = articuloOpService.ListPage(param);

            ProductoListaPaginadaDTO plp = new ProductoListaPaginadaDTO();
            plp.TotalReg = param.TotalReg;
            plp.Productos = mapper.Map<List<ProductoDTO>>(tmp);


            return plp;
        }

        public ProductoDTO Save(ProductoInsertParamDTO producto)
        {
            Articulo articulo = mapper.Map<Articulo>(producto);
            Articulo a = articuloOpService.Save(articulo);
            ProductoDTO res = mapper.Map<ProductoDTO>(a);
            return res;
        }

        public ProductoDTO Update(ProductoUpdateParamDTO producto)
        {
            Articulo articulo = mapper.Map<Articulo>(producto);
            Articulo a = articuloOpService.Save(articulo);
            ProductoDTO res = mapper.Map<ProductoDTO>(a);
            return res;
        }

        public ProductoImagenResponseDTO UploadImage(ProductoImagenParamDTO param)
        {
            FileInfo f = new FileInfo(param.File.FileName);
            string generado = Guid.NewGuid().ToString() + f.Extension;
            string rutaFisica = Path.Combine(ruta, generado);
            using (var stream = new FileStream(rutaFisica, FileMode.Create))
            {
                param.File.CopyTo(stream);
            };

            ArticuloImagen ai = new ArticuloImagen();
            ai.IdArticulo = param.Codigo;
            ai.NombreArchivo = param.File.FileName;
            ai.NombreGenerado = generado;

            ArticuloImagen res = articuloOpService.SaveImage(ai);
            ProductoImagenResponseDTO pir = new ProductoImagenResponseDTO()
            {
                CodigoImagen = res.IdArticuloImagen,
                Url = $"{rutaFisica}"
            };
            return pir;
        }
    }
}
