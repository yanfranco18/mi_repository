using ApiVentas.ApiRest.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.Contexto.Configurations
{
    public class ArticuloImagenConfiguration
        : IEntityTypeConfiguration<ArticuloImagen>
    {
        public void Configure(EntityTypeBuilder<ArticuloImagen> builder)
        {
            builder.ToTable("ProductImage", "DBO");
            builder.HasKey(t => t.IdArticuloImagen);

            builder.HasOne<Articulo>(t => t.Articulo)
                .WithMany(x => x.ArticuloImagen)
                .HasForeignKey(x => x.IdArticulo);
        }
    }
}
