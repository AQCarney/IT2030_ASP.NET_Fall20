using Microsoft.EntityFrameworkCore;

namespace FrequentQuestions.Models
{
    public class QuestionContext : DbContext
    {
        public QuestionContext(DbContextOptions<QuestionContext> options)
            : base(options)
        { }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = "GN", CategoryName = "General" },
                new Category { CategoryID = "HS", CategoryName = "History" });

            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = "BS", TopicName = "Bootstrap"},
                new Topic { TopicId = "C#", TopicName = "C#"},
                new Topic { TopicId = "JS", TopicName = "JavaScript"}
                );

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    QuestionId = 1,
                    Faq = "What is Bootstrap?",
                    Answer = "A CSS framework for creating responsive web apps for multiple screen sizes",
                    CategoryId = "GN",
                    TopicId = "BS"
                    
                },
                new Question
                {
                    QuestionId = 2,
                    Faq = "What is C#?",
                    Answer = "A general purpose object oriented language that uses a concise, Java-like syntax.",
                    CategoryId = "GN",
                    TopicId = "C#"
                    
                },
                new Question
                {
                    QuestionId = 3,
                    Faq = "What is JavaScript?",
                    Answer = "A general purpose scripting language that executes in a web browser.",
                    CategoryId = "GN",
                    TopicId = "JS"
                    
                },
                new Question
                {
                    QuestionId = 4,
                    Faq = "When was Bootstrap first released?",
                    Answer = "In 2011",
                    CategoryId = "HS",
                    TopicId = "BS"
                    
                },
                new Question
                {
                    QuestionId = 5,
                    Faq = "When was C# first released?",
                    Answer = "In 2002",
                    CategoryId = "HS",
                    TopicId = "C#"
                    
                }
                );

        }
        
    }
}
