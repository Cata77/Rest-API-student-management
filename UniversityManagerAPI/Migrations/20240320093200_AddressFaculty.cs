using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddressFaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Faculties",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Faculties");
        }
    }
}
