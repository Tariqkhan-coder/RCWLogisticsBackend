using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSWLogistics.Migrations
{
    /// <inheritdoc />
    public partial class ad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ProofOfVanOwnership",
                table: "Drivers",
                type: "NVARCHAR(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehicleRegistration",
                table: "Drivers",
                type: "NVARCHAR(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehicleVIN",
                table: "Drivers",
                type: "NVARCHAR(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ProofOfVanOwnership",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "VehicleRegistration",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "VehicleVIN",
                table: "Drivers");
        }
    }
}
