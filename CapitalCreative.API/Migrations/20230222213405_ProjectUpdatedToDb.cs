using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapitalCreative.API.Migrations
{
    /// <inheritdoc />
    public partial class ProjectUpdatedToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Project",
                newName: "ShortDescription");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Project",
                newName: "DateCommissioned");

            migrationBuilder.AddColumn<string>(
                name: "DetailedDescription",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailedDescription",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Project",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "DateCommissioned",
                table: "Project",
                newName: "Date");
        }
    }
}
