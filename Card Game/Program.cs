using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>()
            {
                new Player("John"),
                new Player("David")
            };
            Game game = new Game(players);
            game.Main();
        }
    }
}
