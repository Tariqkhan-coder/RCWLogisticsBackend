using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSWLogistics.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CDL",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "IRPRegistration",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "InsuranceCertificate",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "MedicalCertificate",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "VehicleVIN",
                table: "Drivers",
                newName: "TruckType");

            migrationBuilder.RenameColumn(
                name: "VehicleRegistration",
                table: "Drivers",
                newName: "Documents");

            migrationBuilder.RenameColumn(
                name: "ProofOfVanOwnership",
                table: "Drivers",
                newName: "AdditionalEquipmentNotes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TruckType",
                table: "Drivers",
                newName: "VehicleVIN");

            migrationBuilder.RenameColumn(
                name: "Documents",
                table: "Drivers",
                newName: "VehicleRegistration");

            migrationBuilder.RenameColumn(
                name: "AdditionalEquipmentNotes",
                table: "Drivers",
                newName: "ProofOfVanOwnership");

            migrationBuilder.AddColumn<string>(
                name: "CDL",
                table: "Drivers",
                type: "NVARCHAR(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IRPRegistration",
                table: "Drivers",
                type: "NVARCHAR(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InsuranceCertificate",
                table: "Drivers",
                type: "NVARCHAR(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedicalCertificate",
                table: "Drivers",
                type: "NVARCHAR(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");
        }
    }
}
