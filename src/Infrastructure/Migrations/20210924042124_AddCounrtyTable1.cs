using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorHero.CleanArchitecture.Infrastructure.Migrations
{
    public partial class AddCounrtyTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarbonCalculateSet_Country_CountryId",
                table: "CarbonCalculateSet");

            migrationBuilder.DropIndex(
                name: "IX_CarbonCalculateSet_CountryId",
                table: "CarbonCalculateSet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CarbonCalculateSet_CountryId",
                table: "CarbonCalculateSet",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarbonCalculateSet_Country_CountryId",
                table: "CarbonCalculateSet",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
