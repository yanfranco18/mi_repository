using ApiVentas.ApiRest.Managers.OpManager;
using ApiVentas.ApiRest.Services.OpServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ApiVentas.ApiRest.Utils
{
    public static class Extensions
    {

        public static void AddInjections(this IServiceCollection services)
        {

            services.AddTransient<IProductoOpManager, ProductoOpManager>();
            services.AddTransient<IArticuloOpService, ArticuloOpService>();
            services.AddTransient<IPedidoOpManager, PedidoOpManager>();
            services.AddTransient<IPedidoOpService, PedidoOpService>();
            services.AddTransient<ISeguridadOpManager, SeguridadOpManager>();
            services.AddTransient<ISeguridadOpService, SeguridadOpService>();
        }


        public static void ExceptionManager(
            this IApplicationBuilder app,
            ILogger<Startup> logger)
        {

            app.UseExceptionHandler(err =>
            {
                err.Run(async context =>
                {
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        string codigo = Guid.NewGuid().ToString();
                        logger.LogError($"Error inesperado: {codigo} - {contextFeature.Error}");

                        ErrorDetails ed = new ErrorDetails
                        {
                            InternalCode = codigo,
                            Message = "Error interno en la aplicacion",
                            StatusCode = context.Response.StatusCode
                        };

                        await context.Response.WriteAsync(ed.ToString());
                    }

                });

            });

        }
    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string InternalCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
