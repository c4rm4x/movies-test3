using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Movies.Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlContent("../Movies.Persistence/Migrations/20201128125549_SeedData_Up.sql"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.Sql(SqlContent("../Movies.Persistence/Migrations/20201128125549_SeedData_Down.sql"));
        }

        private static string SqlContent(string filename) => File.ReadAllText(filename);
    }
}
