using ApiVentas.ApiRest.Managers.DTO;
using ApiVentas.ApiRest.Services.Contexto;
using ApiVentas.ApiRest.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.OpServices
{
    public class ArticuloOpService : IArticuloOpService
    {
        private readonly VentasContext context;
        private readonly ILogger<ArticuloOpService> logger;

        public ArticuloOpService(
            VentasContext context,
            ILogger<ArticuloOpService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<int> Delete(int IdArticulo)
        {
            var tmp = await context.Articulo.FirstOrDefaultAsync(t => t.IdArticulo == IdArticulo);
            context.Remove(tmp);
            var res =  await context.SaveChangesAsync();
            return res;
        }

        public Articulo Get(int id)
        {
            return context.Articulo.FirstOrDefault(t => t.IdArticulo == id);
        }

        public List<Articulo> List()
        {
            return context.Articulo.ToList();
        }

        public List<Articulo> ListPage(ProductoListaPaginadaParamDTO param)
        {
            //Iqueryrable
            var query = (from x in context.Articulo.Include(t => t.ArticuloImagen)
                         select x);

            if (!string.IsNullOrEmpty(param.Filtro))
            {
                query = query.Where(t => t.Nombre.ToUpper().Contains(param.Filtro.ToUpper()));
            }
            param.TotalReg = query.Count();

            if (param.Order == "codigo")
            {
                query = query.OrderBy(t => t.IdArticulo);
            }
            else if(param.Order == "nombre")
            {
                query = query.OrderBy(t => t.Nombre);
            }
            var res = query.Skip(param.NroPagina * param.RegPagina).Take(param.RegPagina).AsNoTracking().ToList();

            return res;
        }

        public Articulo Save(Articulo articulo)
        {
            /*
            string numero = "10";
            int nro = 0;
            if (!int.TryParse(numero, out nro))
            {
                nro = 10;
            }

            try
            {
                nro = Convert.ToInt32(numero);

            }
            catch  
            {
                nro = 10;
            }
            */

            try
            {
                if (articulo.IdArticulo > 0)
                {
                    context.Articulo.Add(articulo);
                }
                else
                {
                    context.Articulo.Update(articulo);
                }
                context.SaveChanges();
                return articulo;
            }
            catch (Exception ex)
            {
                logger.LogError("error en la grabacion", ex);
                throw;
            }
           
        }

        public ArticuloImagen SaveImage(ArticuloImagen articuloImagen)
        {
            
            context.ArticuloImagen.Add(articuloImagen);
            context.SaveChanges();
            return articuloImagen;
        }
    }
}
