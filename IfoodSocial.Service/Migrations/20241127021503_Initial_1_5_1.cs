using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IfoodSocial.Service.Migrations
{
    /// <inheritdoc />
    public partial class Initial_1_5_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dcr_cidade",
                table: "Cidades",
                newName: "Dcr_Cidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dcr_Cidade",
                table: "Cidades",
                newName: "dcr_cidade");
        }
    }
}
