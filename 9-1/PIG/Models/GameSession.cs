using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIG.Models
{
    public class GameSession
    {
        private ISession session;
        private const string GameKey = "pigGame";
        public GameSession(ISession session)
        {
            this.session = session;
        }
        public void SetGame(Game game)
        {
            session.SetObject(GameKey, game);
        }
        public Game GetGame()
        {
            return session.GetObject<Game>(GameKey) ?? new Game();
        }
    }
}
