using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YukihiraKitchen.Persistence.Migrations
{
    public partial class DirectionModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Directions",
                table: "Directions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Directions");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "Directions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "DirectionId",
                table: "Directions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directions",
                table: "Directions",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Directions_RecipeId",
                table: "Directions",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Directions",
                table: "Directions");

            migrationBuilder.DropIndex(
                name: "IX_Directions_RecipeId",
                table: "Directions");

            migrationBuilder.DropColumn(
                name: "DirectionId",
                table: "Directions");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "Directions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Directions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directions",
                table: "Directions",
                column: "RecipeId");
        }
    }
}
