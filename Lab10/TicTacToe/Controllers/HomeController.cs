using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            TicTacToeBoard board = new TicTacToeBoard();
            List<Cell> cells = board.GetCells();

            foreach (Cell cell in cells)
            {
                cell.Mark = TempData[cell.Id]?.ToString();
            }
            board.CheckForWinner();


            TicTacToeViewModel model = new TicTacToeViewModel
            {
                Cells = cells,
                Selected = new Cell { Mark = TempData["nextTurn"]?.ToString() ?? "X" },
                IsGameOver = board.HasWinner || board.HasAllCellsSelected
            };

            if (model.IsGameOver)
            {
                TempData["nextTurn"] = "X";
                TempData["message"] = board.HasWinner ? $"{board.WinningMark} wins!" : "It's a tie!";
            }
            else
            {
                TempData.Keep();
            }
            return View(model);
        }
        [HttpPost]
        public RedirectToActionResult Index(TicTacToeViewModel viewModel)
        {
            TempData[viewModel.Selected.Id] = viewModel.Selected.Mark;
            TempData["nextTurn"] = viewModel.Selected.Mark == "X" ? "O" : "X";
            return RedirectToAction("Index");
        }
    }
}
