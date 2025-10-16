using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class Persistance
    {
        public class AppDbContext : DbContext
        {

            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

            public DbSet<Prioridad> Prioridades { get; set; }
            public DbSet<Estado> Estados { get; set; }
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Producto> Productos { get; set; }
            public DbSet<Pedido> Pedidos { get; set; }
            public DbSet<DetallePedidoProducto> DetallePedidoProductos { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Prioridad
                modelBuilder.Entity<Prioridad>(entity =>
                {
                    entity.ToTable("Prioridad");
                    entity.HasKey(e => e.PRI_IdPrioridad);
                    entity.Property(e => e.PRI_NombrePrioridad)
                          .IsRequired()
                          .HasMaxLength(50);
                    entity.Property(e => e.PRI_Activo).HasDefaultValue(true);
                    entity.Property(e => e.PRI_FechaCreacion)
                          .HasDefaultValueSql("GETDATE()");
                });

                // Estado
                modelBuilder.Entity<Estado>(entity =>
                {
                    entity.ToTable("Estado");
                    entity.HasKey(e => e.EST_IDEstado);
                    entity.Property(e => e.EST_NombreEstado)
                          .IsRequired()
                          .HasMaxLength(50);
                    entity.Property(e => e.EST_Activo).HasDefaultValue(true);
                    entity.Property(e => e.EST_FechaCreacion)
                          .HasDefaultValueSql("GETDATE()");
                });

                // Cliente
                modelBuilder.Entity<Cliente>(entity =>
                {
                    entity.ToTable("Cliente");
                    entity.HasKey(e => e.CLI_IdCliente);
                    entity.Property(e => e.CLI_Identificacion)
                          .IsRequired()
                          .HasMaxLength(20);
                    entity.HasIndex(e => e.CLI_Identificacion).IsUnique();
                    entity.Property(e => e.CLI_Nombre)
                          .IsRequired()
                          .HasMaxLength(150);
                    entity.Property(e => e.CLI_Direccion)
                          .HasMaxLength(200);
                    entity.Property(e => e.CLI_Telefono)
                          .HasMaxLength(20);
                    entity.Property(e => e.CLI_FechaCreacion)
                          .HasDefaultValueSql("GETDATE()");
                });

                // Producto
                modelBuilder.Entity<Producto>(entity =>
                {
                    entity.ToTable("Producto");
                    entity.HasKey(e => e.PRO_IdProducto);
                    entity.Property(e => e.PRO_Codigo)
                          .IsRequired()
                          .HasMaxLength(50);
                    entity.HasIndex(e => e.PRO_Codigo).IsUnique();
                    entity.Property(e => e.PRO_Nombre)
                          .IsRequired()
                          .HasMaxLength(150);
                    entity.Property(e => e.PRO_ValorUnitario)
                          .IsRequired()
                          .HasColumnType("decimal(10,2)");
                    entity.Property(e => e.PRO_Activo)
                          .HasDefaultValue(true);
                    entity.Property(e => e.PRO_FechaCreacion)
                          .HasDefaultValueSql("GETDATE()");
                });

                // Pedido
                modelBuilder.Entity<Pedido>(entity =>
                {
                    entity.ToTable("Pedido");
                    entity.HasKey(e => e.PED_IdPedido);

                    entity.Property(e => e.PED_FechaRegistro)
                          .HasDefaultValueSql("GETDATE()");

                    entity.Property(e => e.PED_DireccionEntrega)
                          .HasMaxLength(200);

                    entity.Property(e => e.PED_ValorParcialoTotal)
                          .HasColumnType("decimal(12,2)")
                          .HasDefaultValue(0);

                    entity.Property(e => e.PED_FechaCreacion)
                          .HasDefaultValueSql("GETDATE()");

                    entity.HasOne(e => e.Cliente)
                          .WithMany()
                          .HasForeignKey(e => e.CLI_IdCliente)
                          .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(e => e.Estado)
                          .WithMany()
                          .HasForeignKey(e => e.EST_IDEstado)
                          .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(e => e.Prioridad)
                          .WithMany()
                          .HasForeignKey(e => e.PRI_IdPrioridad)
                          .OnDelete(DeleteBehavior.Restrict);
                });

                // DetallePedidoProducto
                modelBuilder.Entity<DetallePedidoProducto>(entity =>
                {
                    entity.ToTable("DetallePedidoProducto");
                    entity.HasKey(e => e.DPP_IdDetalle);

                    entity.Property(e => e.DPP_Cantidad)
                          .IsRequired();

                    entity.Property(e => e.DPP_FechaCreacion)
                          .HasDefaultValueSql("GETDATE()");

                    entity.HasOne(e => e.Pedido)
                          .WithMany(p => p.Detalles)
                          .HasForeignKey(e => e.PED_IdPedido)
                          .OnDelete(DeleteBehavior.Cascade);

                    entity.HasOne(e => e.Producto)
                          .WithMany()
                          .HasForeignKey(e => e.PRO_IdProducto)
                          .OnDelete(DeleteBehavior.Restrict);
                });
            }
        }
    }
}
