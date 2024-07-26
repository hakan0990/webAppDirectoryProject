using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelefonRehberi.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelefonNo",
                table: "newResults");

            migrationBuilder.DropColumn(
                name: "email",
                table: "newResults");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TelefonNo",
                table: "newResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "newResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
