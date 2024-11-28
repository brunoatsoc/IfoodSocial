using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IfoodSocial.Service.Migrations
{
    /// <inheritdoc />
    public partial class Initial_1_5_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Cod_Cidade = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dcr_cidade = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Cod_Cidade);
                });

            migrationBuilder.CreateTable(
                name: "Bairros",
                columns: table => new
                {
                    Cod_Bairro = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dcr_Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    Cod_Cidade = table.Column<int>(type: "INTEGER", nullable: false),
                    CidadeCod_Cidade = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bairros", x => x.Cod_Bairro);
                    table.ForeignKey(
                        name: "FK_Bairros_Cidades_CidadeCod_Cidade",
                        column: x => x.CidadeCod_Cidade,
                        principalTable: "Cidades",
                        principalColumn: "Cod_Cidade");
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Cod_Localidade = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dcr_Localidade = table.Column<string>(type: "TEXT", nullable: true),
                    Cod_Bairro = table.Column<int>(type: "INTEGER", nullable: false),
                    BairroCod_Bairro = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Cod_Localidade);
                    table.ForeignKey(
                        name: "FK_Localidades_Bairros_BairroCod_Bairro",
                        column: x => x.BairroCod_Bairro,
                        principalTable: "Bairros",
                        principalColumn: "Cod_Bairro");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bairros_CidadeCod_Cidade",
                table: "Bairros",
                column: "CidadeCod_Cidade");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_BairroCod_Bairro",
                table: "Localidades",
                column: "BairroCod_Bairro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Bairros");

            migrationBuilder.DropTable(
                name: "Cidades");
        }
    }
}
