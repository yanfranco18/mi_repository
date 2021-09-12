using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVentas.ApiRest.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiVentas.ApiRest.Services.Contexto.Configurations
{
    public class ArticuloConfiguration
        : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.ToTable("Product", "DBO");
            builder.HasKey(t => t.IdArticulo);
            //En el caso que tuviesemos 2 claves primarias
            //builder.HasKey(t => new { t.IdArticulo, t.Nombre });
            builder.Property(t => t.IdArticulo).HasColumnName("ProductId");// en caso de omitir identity .ValueGeneratedNever();
            //customizar el tipo de datos destino
            builder.Property(t => t.Nombre).HasColumnType("varchar(150)");

            List<Articulo> lista = new List<Articulo>();

            for (int i = 1; i <= 100; i++)
            {
                lista.Add(new Articulo { IdArticulo = i, Nombre = $"Articulo {i}", Precio = i + 100 });
            }

            //Seed
            builder.HasData(lista);
        }
    }
}
