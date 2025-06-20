using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtosMoBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class Migration5UserDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaryModel_User_UserID",
                table: "SalaryModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryModel",
                table: "SalaryModel");

            migrationBuilder.RenameTable(
                name: "SalaryModel",
                newName: "Salary");

            migrationBuilder.RenameIndex(
                name: "IX_SalaryModel_UserID",
                table: "Salary",
                newName: "IX_Salary_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salary",
                table: "Salary",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_User_UserID",
                table: "Salary",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salary_User_UserID",
                table: "Salary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salary",
                table: "Salary");

            migrationBuilder.RenameTable(
                name: "Salary",
                newName: "SalaryModel");

            migrationBuilder.RenameIndex(
                name: "IX_Salary_UserID",
                table: "SalaryModel",
                newName: "IX_SalaryModel_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryModel",
                table: "SalaryModel",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryModel_User_UserID",
                table: "SalaryModel",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
