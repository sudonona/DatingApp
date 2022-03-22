using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users", // crea una tabella chiamata users
                columns: table => new // crea due colone id e username
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false) // int di tipo integer
                        .Annotation("Sqlite:Autoincrement", true), // sara autoincrement
                    Username = table.Column<string>(type: "TEXT", nullable: true) //Username di tipo string
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id); //aggiunge chiave primaria 
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users"); // Cancella la tabella Users
        }
    }
}
