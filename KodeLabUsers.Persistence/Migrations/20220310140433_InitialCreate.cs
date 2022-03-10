using Microsoft.EntityFrameworkCore.Migrations;

namespace KodeLabUsers.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    CustId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.CustId);
                    table.ForeignKey(
                        name: "FK_Details_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "LineOne", "LineTwo", "PostCode" },
                values: new object[] { 1, "Pmb", "ZA", "Home", " Street", "3201" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "LineOne", "LineTwo", "PostCode" },
                values: new object[] { 2, "Pmb", "ZA", "Home2", " Street2", "3201" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "LineOne", "LineTwo", "PostCode" },
                values: new object[] { 3, "Pmb", "ZA", "Home3", " Street3", "3201" });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "CustId", "AddressId", "Age", "DateOfBirth", "Email", "Firstname", "IdNumber", "Lastname" },
                values: new object[] { 1, 1, 25, "1996", "marcellvanniekerk@gmail.com", "Marcell", "12345678910", "Smith" });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "CustId", "AddressId", "Age", "DateOfBirth", "Email", "Firstname", "IdNumber", "Lastname" },
                values: new object[] { 2, 2, 25, "1980", "johnnyA@gmail.com", "John", "12345678911", "Snow" });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "CustId", "AddressId", "Age", "DateOfBirth", "Email", "Firstname", "IdNumber", "Lastname" },
                values: new object[] { 3, 3, 25, "1997", "kevinSnow@gmail.com", "Kevin", "12345678912", "Eleven" });

            migrationBuilder.CreateIndex(
                name: "IX_Details_AddressId",
                table: "Details",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
