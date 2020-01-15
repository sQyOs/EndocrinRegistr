using Microsoft.EntityFrameworkCore.Migrations;

namespace EndocrinRegistr.Migrations
{
    public partial class correctcaserecorddoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseRecords_Doctors_DoctorsDoctorId",
                table: "CaseRecords");

            migrationBuilder.DropIndex(
                name: "IX_CaseRecords_DoctorsDoctorId",
                table: "CaseRecords");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "CaseRecords");

            migrationBuilder.DropColumn(
                name: "DoctorsDoctorId",
                table: "CaseRecords");

            migrationBuilder.AddColumn<short>(
                name: "DoctorsId",
                table: "CaseRecords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseRecords_DoctorsId",
                table: "CaseRecords",
                column: "DoctorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseRecords_Doctors_DoctorsId",
                table: "CaseRecords",
                column: "DoctorsId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseRecords_Doctors_DoctorsId",
                table: "CaseRecords");

            migrationBuilder.DropIndex(
                name: "IX_CaseRecords_DoctorsId",
                table: "CaseRecords");

            migrationBuilder.DropColumn(
                name: "DoctorsId",
                table: "CaseRecords");

            migrationBuilder.AddColumn<short>(
                name: "DoctorId",
                table: "CaseRecords",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "DoctorsDoctorId",
                table: "CaseRecords",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseRecords_DoctorsDoctorId",
                table: "CaseRecords",
                column: "DoctorsDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseRecords_Doctors_DoctorsDoctorId",
                table: "CaseRecords",
                column: "DoctorsDoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
