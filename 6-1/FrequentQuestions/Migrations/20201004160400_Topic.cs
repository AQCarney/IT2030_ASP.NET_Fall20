using Microsoft.EntityFrameworkCore.Migrations;

namespace FrequentQuestions.Migrations
{
    public partial class Topic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TopicId",
                table: "Questions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<string>(nullable: false),
                    TopicName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { "BS", "Bootstrap" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { "C#", "C#" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TopicId", "TopicName" },
                values: new object[] { "JS", "JavaScript" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "TopicId",
                value: "BS");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                column: "TopicId",
                value: "C#");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 3,
                column: "TopicId",
                value: "JS");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 4,
                column: "TopicId",
                value: "BS");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 5,
                column: "TopicId",
                value: "C#");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TopicId",
                table: "Questions",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Topics_TopicId",
                table: "Questions",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Topics_TopicId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TopicId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Questions");
        }
    }
}
