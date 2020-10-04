using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FrequentQuestions.Models;
using Microsoft.EntityFrameworkCore;

namespace FrequentQuestions.Controllers
{
    public class HomeController : Controller
    {
        private QuestionContext context { get; set; }
        public HomeController(QuestionContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var questions = context.Questions.Include(q => q.Topic)
                .Include(q => q.Category)                
                .OrderBy(q => q.QuestionId).ToList();
            return View(questions);
        }

    }
}
