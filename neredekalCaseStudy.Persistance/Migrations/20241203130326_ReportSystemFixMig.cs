using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace neredekalCaseStudy.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ReportSystemFixMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "RequestedAt",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "Reports",
                newName: "RequestedAt");

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
        }
    }
}
