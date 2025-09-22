using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSWLogistics.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    EmailAddress = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    StreetAddress = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    State = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    ZipCode = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
