using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelefonRehberi.Migrations
{
    /// <inheritdoc />
    public partial class mig11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "newResults");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "newResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
