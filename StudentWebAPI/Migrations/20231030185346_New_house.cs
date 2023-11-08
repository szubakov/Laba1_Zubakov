using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class New_house : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "color",
                table: "ModelsCars");

            migrationBuilder.CreateIndex(
                name: "IX_ModelsCars_markID",
                table: "ModelsCars",
                column: "markID");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelsCars_MarksCars_markID",
                table: "ModelsCars",
                column: "markID",
                principalTable: "MarksCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelsCars_MarksCars_markID",
                table: "ModelsCars");

            migrationBuilder.DropIndex(
                name: "IX_ModelsCars_markID",
                table: "ModelsCars");

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "ModelsCars",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
