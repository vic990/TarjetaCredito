using Microsoft.EntityFrameworkCore.Migrations;

namespace TarjetaCreditoAPI.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TarjetaCredito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titular = table.Column<string>(type: "Varchar(100)", nullable: false),
                    NumeroTarjeta = table.Column<string>(type: "Varchar(16)", nullable: false),
                    FechaExpiracion = table.Column<string>(type: "Varchar(5)", nullable: false),
                    CVV = table.Column<string>(type: "Varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarjetaCredito", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TarjetaCredito");
        }
    }
}
