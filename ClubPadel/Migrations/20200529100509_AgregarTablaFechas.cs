using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubPadel.Migrations
{
    public partial class AgregarTablaFechas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TablaHoy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCliente = table.Column<int>(nullable: false),
                    nomCliente = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    hora = table.Column<string>(nullable: false),
                    fecha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaHoy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TablaMañana",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCliente = table.Column<int>(nullable: false),
                    nomCliente = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    hora = table.Column<string>(nullable: false),
                    fecha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaMañana", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TablaHoy");

            migrationBuilder.DropTable(
                name: "TablaMañana");
        }
    }
}
