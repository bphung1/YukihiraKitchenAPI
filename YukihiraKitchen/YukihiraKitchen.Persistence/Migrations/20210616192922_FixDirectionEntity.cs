using Microsoft.EntityFrameworkCore.Migrations;

namespace YukihiraKitchen.Persistence.Migrations
{
    public partial class FixDirectionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Directions",
                table: "Directions");

            migrationBuilder.DropIndex(
                name: "IX_Directions_RecipeId",
                table: "Directions");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Directions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directions",
                table: "Directions",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Directions",
                table: "Directions");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Directions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directions",
                table: "Directions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Directions_RecipeId",
                table: "Directions",
                column: "RecipeId");
        }
    }
}
