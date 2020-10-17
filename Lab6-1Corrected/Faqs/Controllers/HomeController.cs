using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faqs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Faqs.Controllers
{
    public class HomeController : Controller
    {
        private FaqsContext context { get; set; }
        public HomeController(FaqsContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string topic, string category)
        {
            ViewBag.Topics = context.Topics.OrderBy(t => t.Name).ToList();
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            ViewBag.SelectedTopic = topic;

            IQueryable<FAQ> faqs = context.FAQs
            .Include(f => f.Topic)
            .Include(f => f.Category)
            .OrderBy(f => f.Question);

            if (!string.IsNullOrEmpty(topic))
            {
                faqs = faqs.Where(f => f.TopicId == topic);
                
             }
            if (!string.IsNullOrEmpty(category))
            {
                faqs = faqs.Where(f => f.CategoryId == category);
            }            
            

            return View(faqs.ToList());
        }
    }
}
