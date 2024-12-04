using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace neredekalCaseStudy.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ReportSystemMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelCount",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "PhoneNumberCount",
                table: "Reports");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelCount",
                table: "Reports",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumberCount",
                table: "Reports",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
