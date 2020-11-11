using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIG.Models
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public string CurrentPlayer { get; set; }
        public int PrevRoll { get; set; }
        public int CurrentTotal { get; set; }
        public bool IsGameOver { get; set; }
        public const int WinningScore = 20;
        Random rand = new Random();
        public Game()
        {
            NewGame();
        }

        public void NewGame()
        {
            Player1 = new Player { Name = "Player 1" };
            Player2 = new Player { Name = "Player 2" };
            CurrentPlayer = Player1.Name;
            CurrentTotal = 0;
            PrevRoll = 0;
            IsGameOver = false;


        }
        public void Roll()
        {
            PrevRoll = rand.Next(1, 7);
            if(PrevRoll == 1)
            {
                CurrentTotal = 0;
                ChangeTurn();
            }
            else
            {
                CurrentTotal += PrevRoll;
            }
        }
        public void Hold()
        {
            Player current = (CurrentPlayer == Player1.Name) ? Player1 : Player2;
            current.Score += CurrentTotal;
            if(current.Score >= WinningScore)
            {
                IsGameOver = true;
            }
            else
            {
                CurrentTotal = 0;
                PrevRoll = 0;
                ChangeTurn();
            }
        }
        public void ChangeTurn()
        {
           CurrentPlayer = (CurrentPlayer == Player1.Name) ? Player2.Name : Player1.Name; 
        }
    }
}
