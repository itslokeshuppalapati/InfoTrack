using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebScrapper.Data.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SearchEngines",
                columns: new[] { "Id", "BaseUrl", "ResultExtractionExpression", "SearchUrl", "Title" },
                values: new object[] { 1, "http://www.google.co.uk", $"((<div class=\\\"gMi0 kCrYT\\\"><a href=\\\"/url\\?q=)(.+?)(&sa=U&ved=))", "search?q=#SearchText#&num=#NumberResultsToSearchIn#", "Google" });

            migrationBuilder.InsertData(
                table: "SearchEngines",
                columns: new[] { "Id", "BaseUrl", "ResultExtractionExpression", "SearchUrl", "Title" },
                values: new object[] { 2, "http://www.bing.com", "((<cite>)(.+?)(</cite>))", "search?q=#SearchText#", "Bing" });

            migrationBuilder.InsertData(
                table: "SearchEngines",
                columns: new[] { "Id", "BaseUrl", "ResultExtractionExpression", "SearchUrl", "Title" },
                //values: new object[] { 1, "http://www.google.co.uk", "((<div class=\\\"gMi0 kCrYT\\\"><a href=\\\"/url\\?q=)(.+?)(&sa=U&ved=))", "search?q=#SearchText#&num=#NumberResultsToSearchIn#", "Google" });
                values: new object[] { 3, "http://search.brave.com", "([^&]+)", "search?q=#SearchText#&num=#NumberResultsToSearchIn#", "Brave" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SearchEngines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SearchEngines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
               table: "SearchEngines",
               keyColumn: "Id",
               keyValue: 3);
        }
    }
}
