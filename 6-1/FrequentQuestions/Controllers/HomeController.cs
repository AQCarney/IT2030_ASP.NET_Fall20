using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FrequentQuestions.Models;
using Microsoft.EntityFrameworkCore;

namespace FrequentQuestions.Controllers
{
    public class HomeController : Controller
    {
        private QuestionContext context { get; set; }
        public HomeController(QuestionContext context)
        {
            this.context = context;
        }
        [Route("topic/{topic}/category/{category}")]
        [Route("topic/{topic}")]
        [Route("category/{category}")]
        [Route("/")]

       
        public IActionResult Index(string topic, string category)
        {
            ViewBag.Topics = context.Topics.OrderBy(t => t.TopicName).ToList();
            ViewBag.Categories = context.Categories.OrderBy(c => c.CategoryName).ToList();
            ViewBag.SelectedTopic = topic;

            IQueryable<Question> questions = context.Questions
            .Include(f => f.Topic)
            .Include(f => f.Category)            
            .OrderBy(f => f.Faq);
            if (!string.IsNullOrEmpty(topic))
            {
                questions = questions.Where(f => f.TopicId == topic); 
            }
            if (!string.IsNullOrEmpty(category)) 
            {
                questions = questions.Where(f => f.CategoryId == category);
             }
            return View(questions.ToList());
        }

    }
}
