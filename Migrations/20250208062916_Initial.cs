using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca82.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsBorrado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    EsBorrado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Usuarios_Tbl_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Tbl_Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tbl_Rol",
                columns: new[] { "Id", "EsBorrado", "Nombre" },
                values: new object[] { 1, false, "Admin" });

            migrationBuilder.InsertData(
                table: "Tbl_Usuarios",
                columns: new[] { "Id", "EsBorrado", "IdRol", "Nombre", "Password", "UserName" },
                values: new object[] { 1, false, 1, "Emmanuel", "password", "Emmanuel_Rojas" });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Usuarios_IdRol",
                table: "Tbl_Usuarios",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Usuarios");

            migrationBuilder.DropTable(
                name: "Tbl_Rol");
        }
    }
}
