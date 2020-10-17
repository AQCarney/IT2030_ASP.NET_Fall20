namespace Faqs.Models
{
    public class FAQ
    {
        public int FaqId { get; set; }

        public string Question { get; set; }
        public string Answer { get; set; }

        public string TopicId { get; set; }
        public Topic Topic { get; set; }
        
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
