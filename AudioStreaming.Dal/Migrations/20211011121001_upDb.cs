using Microsoft.EntityFrameworkCore.Migrations;

namespace AudioStreaming.Dal.Migrations
{
    public partial class upDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Songs",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Photos",
                newName: "Slug");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Songs",
                newName: "FilePath");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Photos",
                newName: "Path");
        }
    }
}
