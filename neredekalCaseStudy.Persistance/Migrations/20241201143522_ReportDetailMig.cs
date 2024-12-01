using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace neredekalCaseStudy.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ReportDetailMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformations_Hotels_HotelId",
                table: "ContactInformations");

            migrationBuilder.DropColumn(
                name: "InfoContent",
                table: "ContactInformations");

            migrationBuilder.RenameColumn(
                name: "InfoType",
                table: "ContactInformations",
                newName: "Content");

            migrationBuilder.AlterColumn<Guid>(
                name: "HotelId",
                table: "ContactInformations",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ContactInformations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    HotelCount = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumberCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformations_Hotels_HotelId",
                table: "ContactInformations",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformations_Hotels_HotelId",
                table: "ContactInformations");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ContactInformations");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "ContactInformations",
                newName: "InfoType");

            migrationBuilder.AlterColumn<Guid>(
                name: "HotelId",
                table: "ContactInformations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoContent",
                table: "ContactInformations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformations_Hotels_HotelId",
                table: "ContactInformations",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
