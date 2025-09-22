using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSWLogistics.Migrations
{
    /// <inheritdoc />
    public partial class neww : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Loads");
        }
    }
}
