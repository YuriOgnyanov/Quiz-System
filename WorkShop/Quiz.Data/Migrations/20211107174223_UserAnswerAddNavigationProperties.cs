using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizSystem.Data.Migrations
{
    public partial class UserAnswerAddNavigationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnswer",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "UserAnswer");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserUserId",
                table: "UserAnswer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
                name: "IX_UserAnswer_AnswerId",
                table: "UserAnswer",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_IdentityUsersId",
                table: "UserAnswer",
                column: "IdentityUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_QuestionId",
                table: "UserAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_QuizId",
                table: "UserAnswer",
                column: "QuizId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IX_UserAnswer_AnswerId",
                table: "UserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswer_IdentityUsersId",
                table: "UserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswer_QuestionId",
                table: "UserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswer_QuizId",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "IdentityUserUserId",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "IdentityUsersId",
                table: "UserAnswer");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "UserAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswer",
                table: "UserAnswer",
                columns: new[] { "UserId", "QuizId" });
        }
    }
}
