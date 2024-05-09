using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Additionalcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "AdditionalInfos");

            migrationBuilder.AddColumn<bool>(
                name: "IsGraduated",
                table: "StudentProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StudentCardNumber",
                table: "StudentProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentLogin",
                table: "StudentProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "AdditionalInfoId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hobbies",
                table: "AdditionalInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentJob",
                table: "AdditionalInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "AdditionalInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResumeId",
                table: "AdditionalInfos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AdditionalInfoId",
                table: "Courses",
                column: "AdditionalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfos_CourseId",
                table: "AdditionalInfos",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfos_ResumeId",
                table: "AdditionalInfos",
                column: "ResumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInfos_Courses_CourseId",
                table: "AdditionalInfos",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInfos_Resume_ResumeId",
                table: "AdditionalInfos",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AdditionalInfos_AdditionalInfoId",
                table: "Courses",
                column: "AdditionalInfoId",
                principalTable: "AdditionalInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInfos_Courses_CourseId",
                table: "AdditionalInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInfos_Resume_ResumeId",
                table: "AdditionalInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AdditionalInfos_AdditionalInfoId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AdditionalInfoId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalInfos_CourseId",
                table: "AdditionalInfos");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalInfos_ResumeId",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "IsGraduated",
                table: "StudentProfiles");

            migrationBuilder.DropColumn(
                name: "StudentCardNumber",
                table: "StudentProfiles");

            migrationBuilder.DropColumn(
                name: "StudentLogin",
                table: "StudentProfiles");

            migrationBuilder.DropColumn(
                name: "AdditionalInfoId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "AdditionalInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Hobbies",
                table: "AdditionalInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentJob",
                table: "AdditionalInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "AdditionalInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
