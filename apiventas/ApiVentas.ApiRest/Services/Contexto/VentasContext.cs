using ApiVentas.ApiRest.Services.Contexto.Configurations;
using ApiVentas.ApiRest.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.Contexto
{
    public class VentasContext : DbContext
    {
        public VentasContext(
            DbContextOptions<VentasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticuloConfiguration()); // =>modelBuilder.Entity("Compras")
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ArticuloImagenConfiguration());
            /*
            //Separar en una carpeta especializada
            modelBuilder.Entity("Articulo").ToTable("Product");
            modelBuilder.Entity("Articulo").HasKey("IdArticulo");
            modelBuilder.Entity("Articulo").Property("IdArticulo").HasColumnName("ProductId");
            */
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ArticuloImagen> ArticuloImagen { get; set; }
        public DbSet<Opcion> Opcion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
