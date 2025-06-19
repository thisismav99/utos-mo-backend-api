using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtosMoBackendAPI.Migrations.WorkDb
{
    /// <inheritdoc />
    public partial class Migration4WorkDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkIndustries_Industry_IndustriesID",
                table: "WorkIndustries");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkIndustries_Work_WorksID",
                table: "WorkIndustries");

            migrationBuilder.RenameColumn(
                name: "WorksID",
                table: "WorkIndustries",
                newName: "IndustryID");

            migrationBuilder.RenameColumn(
                name: "IndustriesID",
                table: "WorkIndustries",
                newName: "WorkID");

            migrationBuilder.RenameIndex(
                name: "IX_WorkIndustries_WorksID",
                table: "WorkIndustries",
                newName: "IX_WorkIndustries_IndustryID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkIndustries_Industry_IndustryID",
                table: "WorkIndustries",
                column: "IndustryID",
                principalTable: "Industry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkIndustries_Work_WorkID",
                table: "WorkIndustries",
                column: "WorkID",
                principalTable: "Work",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkIndustries_Industry_IndustryID",
                table: "WorkIndustries");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkIndustries_Work_WorkID",
                table: "WorkIndustries");

            migrationBuilder.RenameColumn(
                name: "IndustryID",
                table: "WorkIndustries",
                newName: "WorksID");

            migrationBuilder.RenameColumn(
                name: "WorkID",
                table: "WorkIndustries",
                newName: "IndustriesID");

            migrationBuilder.RenameIndex(
                name: "IX_WorkIndustries_IndustryID",
                table: "WorkIndustries",
                newName: "IX_WorkIndustries_WorksID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkIndustries_Industry_IndustriesID",
                table: "WorkIndustries",
                column: "IndustriesID",
                principalTable: "Industry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkIndustries_Work_WorksID",
                table: "WorkIndustries",
                column: "WorksID",
                principalTable: "Work",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
