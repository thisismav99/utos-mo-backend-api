using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtosMoBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class Migration2UserDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EducationID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HasHonors",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "HonorID",
                table: "Education");

            migrationBuilder.AddColumn<Guid>(
                name: "EducationID",
                table: "Honor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Education",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Address",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EducationID",
                table: "Honor");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressID",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationID",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasHonors",
                table: "Education",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "HonorID",
                table: "Education",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
