using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrequentQuestions.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string Faq { get; set; }
        public string Answer { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string TopicId { get; set; }
        public Topic Topic { get; set; }


    }
}
