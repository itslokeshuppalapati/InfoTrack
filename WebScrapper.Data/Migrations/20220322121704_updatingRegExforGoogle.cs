using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebScrapper.Data.Migrations
{
    public partial class updatingRegExforGoogle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SearchEngines",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResultExtractionExpression",
                value: "gMi0 kCrYT(.+?)sa=U&ved=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SearchEngines",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResultExtractionExpression",
                value: "gMi0 kCrYT(.+?)sa=U&ved=");
        }
    }
}
