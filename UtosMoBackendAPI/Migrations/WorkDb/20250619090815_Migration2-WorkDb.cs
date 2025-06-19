using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtosMoBackendAPI.Migrations.WorkDb
{
    /// <inheritdoc />
    public partial class Migration2WorkDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndustryID",
                table: "Work");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Work",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Industry",
                table: "Industry",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "IndustryModelWorkModel",
                columns: table => new
                {
                    IndustriesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorksID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryModelWorkModel", x => new { x.IndustriesID, x.WorksID });
                    table.ForeignKey(
                        name: "FK_IndustryModelWorkModel_Industry_IndustriesID",
                        column: x => x.IndustriesID,
                        principalTable: "Industry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndustryModelWorkModel_Work_WorksID",
                        column: x => x.WorksID,
                        principalTable: "Work",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndustryModelWorkModel_WorksID",
                table: "IndustryModelWorkModel",
                column: "WorksID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndustryModelWorkModel");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Work",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<Guid>(
                name: "IndustryID",
                table: "Work",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Industry",
                table: "Industry",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
