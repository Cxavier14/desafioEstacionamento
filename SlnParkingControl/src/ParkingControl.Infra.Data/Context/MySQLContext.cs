using Microsoft.EntityFrameworkCore;
using ParkingControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Infra.Data.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>()
                .HasData(
                new { Id = 1, Placa = "MMD5544", DataHoraEntrada = new DateTime(2023, 07, 04, 14, 00, 00), DataHoraSaida = new DateTime(2023, 07, 04, 14, 10, 00) },
                new { Id = 2, Placa = "DDM8474", DataHoraEntrada = new DateTime(2023, 07, 04, 14, 00, 00), DataHoraSaida = new DateTime(2023, 07, 04, 14, 15, 00) },
                new { Id = 3, Placa = "BRA2E23", DataHoraEntrada = new DateTime(2023, 07, 04, 14, 00, 00), DataHoraSaida = new DateTime(2023, 07, 04, 15, 00, 00) }
                );

            modelBuilder.Entity<Tarifa>()
                .HasData(
                new { Id = 1, Preco = 2.00, DataVigencia = new DateTime(2023, 05, 01, 08, 00, 00) },
                new { Id = 2, Preco = 2.50, DataVigencia = new DateTime(2023, 06, 01, 08, 00, 00) },
                new { Id = 3, Preco = 3.00, DataVigencia = new DateTime(2023, 07, 01, 08, 00, 00) }
                );

            base.OnModelCreating(modelBuilder);
        }

        #region DbSet's
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        #endregion
    }
}