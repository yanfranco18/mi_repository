using ApiVentas.ApiRest.Managers.OpManager;
using ApiVentas.ApiRest.Services.Contexto;
using ApiVentas.ApiRest.Services.OpServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVentas.ApiRest.Utils;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ApiVentas.ApiRest
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string cadena = Configuration.GetValue<string>("CnnSqlServer");
            services.AddDbContext<VentasContext>(opt =>
            {
                opt.UseSqlServer(cadena);

            });

            services.AddInjections();

            //configurar la autenticacion
            //Generar la semilla
            string semilla = "Galaxy123abcdef007";
            byte[] semillarByte = Encoding.UTF8.GetBytes(semilla);
            SymmetricSecurityKey key = new SymmetricSecurityKey(semillarByte);

            services.AddAuthentication
                (JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option => {
                    option.TokenValidationParameters = new TokenValidationParameters { 
                        IssuerSigningKey = key,
                        ValidateLifetime = true,
                        ValidIssuer = "demo.com",
                        ValidAudience = "demo.com",
                        ValidateIssuer = true

                    };
                
                });

            services.AddCors(opt => {
                opt.AddPolicy("Todos", det => {
                    det.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
                opt.AddPolicy("SoloAngular", det => {
                    det.WithOrigins("http://localhost:4200").WithMethods(new string[] { "Get", "Post" }).AllowAnyHeader();
                });
            });


            //Activar el automapper
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiVentas.ApiRest", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiVentas.ApiRest v1"));
            }
            else
            {
                //app.ExceptionManager(logger);

            }
            app.ExceptionManager(logger);
            app.UseRouting();
            app.UseCors("SoloAngular");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
