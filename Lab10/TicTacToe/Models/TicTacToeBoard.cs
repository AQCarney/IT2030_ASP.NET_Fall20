using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class TicTacToeBoard
    {
        public TicTacToeBoard()
        {
            string[] rows = new string[] { "Top", "Middle", "Bbottom" };
            string[] cols = new string[] { "Left", "Middle", "Right" };

            cells = new List<Cell>();

            foreach (string row in rows)
            {
                foreach (string col in cols)
                {
                    Cell cell = new Cell { Id = row + col };
                    cells.Add(cell);
                }
            }

        }
        private List<Cell> cells { get; set; }
        public List<Cell> GetCells() => cells;

        public bool HasWinner { get; set; }
        public string WinningMark { get; set; }
        public bool HasAllCellsSelected { get; set; }

        public void CheckForWinner()
        {
            string winningMark = null;

            switch (true)
            {
                case true when IsWinner(0, 1, 2, out winningMark):
                case true when IsWinner(3, 4, 5, out winningMark):
                case true when IsWinner(6, 7, 8, out winningMark):
                case true when IsWinner(0, 3, 6, out winningMark):
                case true when IsWinner(1, 4, 7, out winningMark):
                case true when IsWinner(2, 5, 8, out winningMark):
                case true when IsWinner(0, 4, 8, out winningMark):
                case true when IsWinner(2, 7, 6, out winningMark):
                    HasWinner = true;
                    break;
                default:
                    HasWinner = false;
                    break;
            }

            WinningMark = winningMark;
            HasAllCellsSelected = true;

            foreach (Cell cell in cells)
            {
                if (cell.IsBlank)
                {
                    HasAllCellsSelected = false;
                    return;
                }
            }
        }

        private bool IsWinner(int mark1, int mark2, int mark3, out string winningMark)
        {
            if(cells[mark1].Mark == cells[mark2].Mark && cells[mark2].Mark == cells[mark3].Mark && !string.IsNullOrEmpty(cells[mark1].Mark))
            {
                winningMark = cells[mark1].Mark;
                return true;
            }
            winningMark = null;
            return false;
        }
    }
}
