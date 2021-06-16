using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YukihiraKitchen.Persistence.Migrations
{
    public partial class FixPhotoRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Photos_PhotoId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_PhotoId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Recipes_RecipeId",
                table: "Photos",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Recipes_RecipeId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "PhotoId",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Photos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_PhotoId",
                table: "Recipes",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Photos_PhotoId",
                table: "Recipes",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
