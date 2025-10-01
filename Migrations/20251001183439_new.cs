using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCWLogisticsBackend.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

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
                    ZipCode = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    Documents = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    TruckType = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    AdditionalEquipmentNotes = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "Loads",
                columns: table => new
                {
                    LoadId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    ContactNumber = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    PickUpLocation = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    DropOffLocation = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    PickUpDate = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    DeliveryDate = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    EquipmentType = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    Weight = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    Dimensions = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    Documents = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    TargetRate = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    AdditionalNotes = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loads", x => x.LoadId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Loads");
        }
    }
}
