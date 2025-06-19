using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtosMoBackendAPI.Migrations.WorkDb
{
    /// <inheritdoc />
    public partial class Migration3WorkDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndustryModelWorkModel_Industry_IndustriesID",
                table: "IndustryModelWorkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_IndustryModelWorkModel_Work_WorksID",
                table: "IndustryModelWorkModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndustryModelWorkModel",
                table: "IndustryModelWorkModel");

            migrationBuilder.RenameTable(
                name: "IndustryModelWorkModel",
                newName: "WorkIndustries");

            migrationBuilder.RenameIndex(
                name: "IX_IndustryModelWorkModel_WorksID",
                table: "WorkIndustries",
                newName: "IX_WorkIndustries_WorksID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkIndustries",
                table: "WorkIndustries",
                columns: new[] { "IndustriesID", "WorksID" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkIndustries_Industry_IndustriesID",
                table: "WorkIndustries");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkIndustries_Work_WorksID",
                table: "WorkIndustries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkIndustries",
                table: "WorkIndustries");

            migrationBuilder.RenameTable(
                name: "WorkIndustries",
                newName: "IndustryModelWorkModel");

            migrationBuilder.RenameIndex(
                name: "IX_WorkIndustries_WorksID",
                table: "IndustryModelWorkModel",
                newName: "IX_IndustryModelWorkModel_WorksID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndustryModelWorkModel",
                table: "IndustryModelWorkModel",
                columns: new[] { "IndustriesID", "WorksID" });

            migrationBuilder.AddForeignKey(
                name: "FK_IndustryModelWorkModel_Industry_IndustriesID",
                table: "IndustryModelWorkModel",
                column: "IndustriesID",
                principalTable: "Industry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndustryModelWorkModel_Work_WorksID",
                table: "IndustryModelWorkModel",
                column: "WorksID",
                principalTable: "Work",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
