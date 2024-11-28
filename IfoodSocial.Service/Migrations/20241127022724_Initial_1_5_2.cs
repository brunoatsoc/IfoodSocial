using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IfoodSocial.Service.Migrations
{
    /// <inheritdoc />
    public partial class Initial_1_5_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dcr_Cidade",
                table: "Bairros",
                newName: "Dcr_Bairro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dcr_Bairro",
                table: "Bairros",
                newName: "Dcr_Cidade");
        }
    }
}
