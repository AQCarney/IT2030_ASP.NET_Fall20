using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIG.Models;

namespace PIG.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            GameSession session = new GameSession(HttpContext.Session);
            Game game = session.GetGame();
            if (game.IsGameOver)
            {
                TempData["message"] = $"{game.CurrentPlayer} wins!";
            }

            return View(game);
        }
        [HttpPost]
        public RedirectToActionResult NewGame()
        {
            GameSession session = new GameSession(HttpContext.Session);
            Game game = session.GetGame();
            game.NewGame();
            session.SetGame(game);


            return RedirectToAction("Index");
        }
        [HttpPost]
        public RedirectToActionResult Roll()
        {
            GameSession session = new GameSession(HttpContext.Session);
            Game game = session.GetGame();
            game.Roll();

            session.SetGame(game);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public RedirectToActionResult Hold()
        {
            GameSession session = new GameSession(HttpContext.Session);
            Game game = session.GetGame();
            game.Hold();
            session.SetGame(game);


            return RedirectToAction("Index");
        }
    }
}
