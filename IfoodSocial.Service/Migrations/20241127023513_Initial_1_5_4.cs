using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IfoodSocial.Service.Migrations
{
    /// <inheritdoc />
    public partial class Initial_1_5_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bairros_Cidades_Cod_Bairro",
                table: "Bairros");

            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Bairros_Cod_Localidade",
                table: "Localidades");

            migrationBuilder.AlterColumn<int>(
                name: "Cod_Localidade",
                table: "Localidades",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "BairroCod_Bairro",
                table: "Localidades",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cod_Bairro",
                table: "Bairros",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "CidadeCod_Cidade",
                table: "Bairros",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_BairroCod_Bairro",
                table: "Localidades",
                column: "BairroCod_Bairro");

            migrationBuilder.CreateIndex(
                name: "IX_Bairros_CidadeCod_Cidade",
                table: "Bairros",
                column: "CidadeCod_Cidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Bairros_Cidades_CidadeCod_Cidade",
                table: "Bairros",
                column: "CidadeCod_Cidade",
                principalTable: "Cidades",
                principalColumn: "Cod_Cidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Bairros_BairroCod_Bairro",
                table: "Localidades",
                column: "BairroCod_Bairro",
                principalTable: "Bairros",
                principalColumn: "Cod_Bairro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bairros_Cidades_CidadeCod_Cidade",
                table: "Bairros");

            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Bairros_BairroCod_Bairro",
                table: "Localidades");

            migrationBuilder.DropIndex(
                name: "IX_Localidades_BairroCod_Bairro",
                table: "Localidades");

            migrationBuilder.DropIndex(
                name: "IX_Bairros_CidadeCod_Cidade",
                table: "Bairros");

            migrationBuilder.DropColumn(
                name: "BairroCod_Bairro",
                table: "Localidades");

            migrationBuilder.DropColumn(
                name: "CidadeCod_Cidade",
                table: "Bairros");

            migrationBuilder.AlterColumn<int>(
                name: "Cod_Localidade",
                table: "Localidades",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Cod_Bairro",
                table: "Bairros",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bairros_Cidades_Cod_Bairro",
                table: "Bairros",
                column: "Cod_Bairro",
                principalTable: "Cidades",
                principalColumn: "Cod_Cidade",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Bairros_Cod_Localidade",
                table: "Localidades",
                column: "Cod_Localidade",
                principalTable: "Bairros",
                principalColumn: "Cod_Bairro",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
