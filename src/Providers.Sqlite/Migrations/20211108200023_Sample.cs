using Microsoft.EntityFrameworkCore.Migrations;

namespace Providers.EntityFramework.Sqlite.Migrations
{
    public partial class Sample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    FieldToDisplay = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Media");
        }
    }
}
