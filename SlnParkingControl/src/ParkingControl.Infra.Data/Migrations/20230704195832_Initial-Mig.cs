using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParkingControl.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tarifas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Preco = table.Column<double>(type: "double", nullable: false),
                    DataVigencia = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataHoraEntrada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataHoraSaida = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Tarifas",
                columns: new[] { "Id", "DataVigencia", "Preco" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 2.0 },
                    { 2, new DateTime(2023, 6, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 2.5 },
                    { 3, new DateTime(2023, 7, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 3.0 }
                });

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "Id", "DataHoraEntrada", "DataHoraSaida", "Placa" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 4, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 4, 14, 10, 0, 0, DateTimeKind.Unspecified), "MMD5544" },
                    { 2, new DateTime(2023, 7, 4, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 4, 14, 15, 0, 0, DateTimeKind.Unspecified), "DDM8474" },
                    { 3, new DateTime(2023, 7, 4, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), "BRA2E23" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarifas");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
