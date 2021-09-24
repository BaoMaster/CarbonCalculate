using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorHero.CleanArchitecture.Infrastructure.Migrations
{
    public partial class UpdateTableCarbonSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarbonCalculateSet_Users_BlazorHeroUserId",
                table: "CarbonCalculateSet");

            migrationBuilder.DropIndex(
                name: "IX_CarbonCalculateSet_BlazorHeroUserId",
                table: "CarbonCalculateSet");

            migrationBuilder.DropColumn(
                name: "BlazorHeroUserId",
                table: "CarbonCalculateSet");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CarbonCalculateSet",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarbonCalculateSet_UserId",
                table: "CarbonCalculateSet",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarbonCalculateSet_Users_UserId",
                table: "CarbonCalculateSet",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarbonCalculateSet_Users_UserId",
                table: "CarbonCalculateSet");

            migrationBuilder.DropIndex(
                name: "IX_CarbonCalculateSet_UserId",
                table: "CarbonCalculateSet");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CarbonCalculateSet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlazorHeroUserId",
                table: "CarbonCalculateSet",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarbonCalculateSet_BlazorHeroUserId",
                table: "CarbonCalculateSet",
                column: "BlazorHeroUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarbonCalculateSet_Users_BlazorHeroUserId",
                table: "CarbonCalculateSet",
                column: "BlazorHeroUserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
