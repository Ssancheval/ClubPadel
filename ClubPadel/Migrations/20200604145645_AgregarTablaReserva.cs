using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubPadel.Migrations
{
    public partial class AgregarTablaReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user",
                table: "Cliente",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Cliente",
                newName: "Password");

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<string>(nullable: false),
                    Pista = table.Column<int>(nullable: false),
                    Hora = table.Column<string>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Cliente",
                newName: "user");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Cliente",
                newName: "password");
        }
    }
}
