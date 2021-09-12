using ApiVentas.ApiRest.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.ApiRest.Services.Contexto.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(t => t.IdPedido);

            builder.HasOne<Cliente>(t => t.Cliente)
                .WithMany(x => x.Pedidos)
                .HasForeignKey(x => x.IdCliente);

        }
    }
}
