using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingControl.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAlteracaoTabelaTarifas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataVigencia",
                table: "Tarifas",
                newName: "DataInicioVigencia");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFimVigencia",
                table: "Tarifas",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataFimVigencia", "DataInicioVigencia" },
                values: new object[] { new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataFimVigencia", "DataInicioVigencia", "Preco" },
                values: new object[] { new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 });

            migrationBuilder.UpdateData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataFimVigencia", "DataInicioVigencia", "Preco" },
                values: new object[] { new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFimVigencia",
                table: "Tarifas");

            migrationBuilder.RenameColumn(
                name: "DataInicioVigencia",
                table: "Tarifas",
                newName: "DataVigencia");

            migrationBuilder.UpdateData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataVigencia",
                value: new DateTime(2023, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataVigencia", "Preco" },
                values: new object[] { new DateTime(2023, 6, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 2.5 });

            migrationBuilder.UpdateData(
                table: "Tarifas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataVigencia", "Preco" },
                values: new object[] { new DateTime(2023, 7, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 3.0 });
        }
    }
}
