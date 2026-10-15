using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndiaTourismExplorer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HighlightId",
                table: "TouristPlaceHighlights",
                newName: "TouristPlaceHighlightId");

            migrationBuilder.AddColumn<string>(
                name: "HighlightText",
                table: "TouristPlaceHighlights",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighlightText",
                table: "TouristPlaceHighlights");

            migrationBuilder.RenameColumn(
                name: "TouristPlaceHighlightId",
                table: "TouristPlaceHighlights",
                newName: "HighlightId");
        }
    }
}
