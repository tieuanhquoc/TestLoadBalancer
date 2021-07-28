using Microsoft.EntityFrameworkCore.Migrations;

namespace TestLoadBalancer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Entity",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1, "Pass", "UserName" });

            migrationBuilder.InsertData(
                table: "Entity",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 2, "Pass2", "UserName2" });

            migrationBuilder.InsertData(
                table: "Entity",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 3, "Pass3", "UserName3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
