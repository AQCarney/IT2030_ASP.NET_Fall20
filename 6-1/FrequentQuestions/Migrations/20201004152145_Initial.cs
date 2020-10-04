using Microsoft.EntityFrameworkCore.Migrations;

namespace FrequentQuestions.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faq = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "Answer", "Faq" },
                values: new object[,]
                {
                    { 1, "A CSS framework for creating responsive web apps for multiple screen sizes", "What is Bootstrap?" },
                    { 2, "A general purpose object oriented language that uses a concise, Java-like syntax.", "What is C#?" },
                    { 3, "A general purpose scripting language that executes in a web browser.", "What is JavaScript?" },
                    { 4, "In 2011", "When was Bootstrap first released?" },
                    { 5, "In 2002", "When was C# first released?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
