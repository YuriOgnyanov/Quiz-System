using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizSystem.Data.Migrations
{
    public partial class ReturnIdentityUserUserIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_Answer_AnswerId",
                table: "UserAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_AspNetUsers_IdentityUsersId",
                table: "UserAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_Questions_QuestionId",
                table: "UserAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_Quizes_QuizId",
                table: "UserAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnswer",
                table: "UserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswer_IdentityUsersId",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "IdentityUsersId",
                table: "UserAnswer");

            migrationBuilder.RenameTable(
                name: "UserAnswer",
                newName: "UserAnswers");

            migrationBuilder.RenameColumn(
                name: "IdentityUserUserId",
                table: "UserAnswers",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswer_QuizId",
                table: "UserAnswers",
                newName: "IX_UserAnswers_QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswer_QuestionId",
                table: "UserAnswers",
                newName: "IX_UserAnswers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswer_AnswerId",
                table: "UserAnswers",
                newName: "IX_UserAnswers_AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers",
                columns: new[] { "IdentityUserId", "QuizId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Answer_AnswerId",
                table: "UserAnswers",
                column: "AnswerId",
                principalTable: "Answer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_AspNetUsers_IdentityUserId",
                table: "UserAnswers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Questions_QuestionId",
                table: "UserAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Quizes_QuizId",
                table: "UserAnswers",
                column: "QuizId",
                principalTable: "Quizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Answer_AnswerId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_AspNetUsers_IdentityUserId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Questions_QuestionId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Quizes_QuizId",
                table: "UserAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers");

            migrationBuilder.RenameTable(
                name: "UserAnswers",
                newName: "UserAnswer");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "UserAnswer",
                newName: "IdentityUserUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_QuizId",
                table: "UserAnswer",
                newName: "IX_UserAnswer_QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "UserAnswer",
                newName: "IX_UserAnswer_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_AnswerId",
                table: "UserAnswer",
                newName: "IX_UserAnswer_AnswerId");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUsersId",
                table: "UserAnswer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswer",
                table: "UserAnswer",
                columns: new[] { "IdentityUserUserId", "QuizId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_IdentityUsersId",
                table: "UserAnswer",
                column: "IdentityUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_Answer_AnswerId",
                table: "UserAnswer",
                column: "AnswerId",
                principalTable: "Answer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_AspNetUsers_IdentityUsersId",
                table: "UserAnswer",
                column: "IdentityUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_Questions_QuestionId",
                table: "UserAnswer",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_Quizes_QuizId",
                table: "UserAnswer",
                column: "QuizId",
                principalTable: "Quizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
