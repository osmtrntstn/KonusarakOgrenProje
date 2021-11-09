using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class version_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExamOptions_ExamQuestions_ExamQuestionID",
                table: "UserExamOptions");

            migrationBuilder.RenameColumn(
                name: "ExamQuestionID",
                table: "UserExamOptions",
                newName: "ExamQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserExamOptions_ExamQuestionID",
                table: "UserExamOptions",
                newName: "IX_UserExamOptions_ExamQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExamOptions_ExamQuestions_ExamQuestionId",
                table: "UserExamOptions",
                column: "ExamQuestionId",
                principalTable: "ExamQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExamOptions_ExamQuestions_ExamQuestionId",
                table: "UserExamOptions");

            migrationBuilder.RenameColumn(
                name: "ExamQuestionId",
                table: "UserExamOptions",
                newName: "ExamQuestionID");

            migrationBuilder.RenameIndex(
                name: "IX_UserExamOptions_ExamQuestionId",
                table: "UserExamOptions",
                newName: "IX_UserExamOptions_ExamQuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExamOptions_ExamQuestions_ExamQuestionID",
                table: "UserExamOptions",
                column: "ExamQuestionID",
                principalTable: "ExamQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
