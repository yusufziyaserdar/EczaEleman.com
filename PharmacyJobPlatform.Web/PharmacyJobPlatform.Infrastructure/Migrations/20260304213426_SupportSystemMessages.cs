using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyJobPlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SupportSystemMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSupportMessage",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSupportReviewed",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SupportReviewedAt",
                table: "Messages",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSupportMessage",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsSupportReviewed",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SupportReviewedAt",
                table: "Messages");
        }
    }
}
