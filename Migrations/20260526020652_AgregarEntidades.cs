using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Administracion_Consorcio_PW3.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consorcios",
                columns: table => new
                {
                    IdConsorcio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProvincia = table.Column<int>(type: "int", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Altura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaVencimientoExpensas = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioCreador = table.Column<int>(type: "int", nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consorcios", x => x.IdConsorcio);
                    table.ForeignKey(
                        name: "FK_Consorcios_Provincias_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "Provincias",
                        principalColumn: "IdProvincia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consorcios_Usuarios_IdUsuarioCreador",
                        column: x => x.IdUsuarioCreador,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposGasto",
                columns: table => new
                {
                    IdTipoGasto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposGasto", x => x.IdTipoGasto);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    IdUnidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdConsorcio = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombrePropietario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPropietario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailPropietario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Superficie = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioCreador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.IdUnidad);
                    table.ForeignKey(
                        name: "FK_Unidades_Consorcios_IdConsorcio",
                        column: x => x.IdConsorcio,
                        principalTable: "Consorcios",
                        principalColumn: "IdConsorcio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unidades_Usuarios_IdUsuarioCreador",
                        column: x => x.IdUsuarioCreador,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Gastos",
                columns: table => new
                {
                    IdGasto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdConsorcio = table.Column<int>(type: "int", nullable: false),
                    IdTipoGasto = table.Column<int>(type: "int", nullable: false),
                    FechaGasto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnioExpensa = table.Column<int>(type: "int", nullable: false),
                    MesExpensa = table.Column<int>(type: "int", nullable: false),
                    ArchivoComprobante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioCreador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos", x => x.IdGasto);
                    table.ForeignKey(
                        name: "FK_Gastos_Consorcios_IdConsorcio",
                        column: x => x.IdConsorcio,
                        principalTable: "Consorcios",
                        principalColumn: "IdConsorcio");
                    table.ForeignKey(
                        name: "FK_Gastos_TiposGasto_IdTipoGasto",
                        column: x => x.IdTipoGasto,
                        principalTable: "TiposGasto",
                        principalColumn: "IdTipoGasto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gastos_Usuarios_IdUsuarioCreador",
                        column: x => x.IdUsuarioCreador,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consorcios_IdProvincia",
                table: "Consorcios",
                column: "IdProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_Consorcios_IdUsuarioCreador",
                table: "Consorcios",
                column: "IdUsuarioCreador");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_IdConsorcio",
                table: "Gastos",
                column: "IdConsorcio");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_IdTipoGasto",
                table: "Gastos",
                column: "IdTipoGasto");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_IdUsuarioCreador",
                table: "Gastos",
                column: "IdUsuarioCreador");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_IdConsorcio",
                table: "Unidades",
                column: "IdConsorcio");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_IdUsuarioCreador",
                table: "Unidades",
                column: "IdUsuarioCreador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gastos");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "TiposGasto");

            migrationBuilder.DropTable(
                name: "Consorcios");
        }
    }
}
