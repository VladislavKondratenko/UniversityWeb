using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace University.Infrastructure.Data.Migrations
{
    public partial class CreateAndFillTestDataDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var path = Path.GetFullPath(@"../../SqlScripts/InsertTestText.sql");
            migrationBuilder.Sql(File.ReadAllText(path));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var path = Path.GetFullPath(@"../../SqlScripts/DropAllDataFromUniversity.sql");
            migrationBuilder.Sql(File.ReadAllText(path));
        }
    }
}