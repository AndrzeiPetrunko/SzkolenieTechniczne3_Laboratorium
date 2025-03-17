using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzkolenieTechniczne.Geo.Storage.Migrations
{
    /// <inheritdoc />
    public partial class CityDtoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Geo",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Geo",
                table: "Cities");
        }
    }
}
