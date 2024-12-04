using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace neredekalCaseStudy.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class NewReportsMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "Reports",
                newName: "RequestedDate");

            migrationBuilder.RenameColumn(
                name: "ReportStatus",
                table: "Reports",
                newName: "Location");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Reports",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalHotels",
                table: "Reports",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPhoneNumbers",
                table: "Reports",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TotalHotels",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TotalPhoneNumbers",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "RequestedDate",
                table: "Reports",
                newName: "RequestDate");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Reports",
                newName: "ReportStatus");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Reports",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
