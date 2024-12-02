using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace neredekalCaseStudy.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class HotelContactMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformations_Hotels_HotelId",
                table: "ContactInformations");

            migrationBuilder.AlterColumn<Guid>(
                name: "HotelId",
                table: "ContactInformations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformations_Hotels_HotelId",
                table: "ContactInformations",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformations_Hotels_HotelId",
                table: "ContactInformations");

            migrationBuilder.AlterColumn<Guid>(
                name: "HotelId",
                table: "ContactInformations",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformations_Hotels_HotelId",
                table: "ContactInformations",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }
    }
}
