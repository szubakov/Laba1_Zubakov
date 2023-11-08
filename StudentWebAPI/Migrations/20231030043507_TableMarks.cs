using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class TableMarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "ModelsCars",
                newName: "privod");

            migrationBuilder.AddColumn<string>(
                name: "DVS",
                table: "ModelsCars",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "ModelsCars",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "engine_capacity",
                table: "ModelsCars",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "groupID",
                table: "ModelsCars",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "kuzov",
                table: "ModelsCars",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "ls",
                table: "ModelsCars",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "MarksCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarksCars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarksCars");

            migrationBuilder.DropColumn(
                name: "DVS",
                table: "ModelsCars");

            migrationBuilder.DropColumn(
                name: "color",
                table: "ModelsCars");

            migrationBuilder.DropColumn(
                name: "engine_capacity",
                table: "ModelsCars");

            migrationBuilder.DropColumn(
                name: "groupID",
                table: "ModelsCars");

            migrationBuilder.DropColumn(
                name: "kuzov",
                table: "ModelsCars");

            migrationBuilder.DropColumn(
                name: "ls",
                table: "ModelsCars");

            migrationBuilder.RenameColumn(
                name: "privod",
                table: "ModelsCars",
                newName: "Country");
        }
    }
}
