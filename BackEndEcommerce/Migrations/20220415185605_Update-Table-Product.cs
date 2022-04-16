using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndEcommerce.Migrations
{
    public partial class UpdateTableProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
