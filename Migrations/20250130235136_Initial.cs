using System;
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRol = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                values: new object[] { new Guid("070ed413-0adf-4f5c-bb9b-cf49fbe4fb6f"), false, "Admin" });

            migrationBuilder.InsertData(
                table: "Tbl_Usuarios",
                columns: new[] { "Id", "EsBorrado", "IdRol", "Nombre", "Password", "UserName" },
                values: new object[] { new Guid("4a995251-8d3b-4518-b5f7-333774af5603"), false, new Guid("070ed413-0adf-4f5c-bb9b-cf49fbe4fb6f"), "Emmanuel", "password", "Emmanuel_Rojas" });

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
