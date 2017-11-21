using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace MatchmakingPrototype2
{
    class Program
    {
        public List<Player> playerList = new List<Player>();

        void Main(string[] args)
        {
            Run();
        }

        private void Run()
        {
            //MatchMaker mm = new MatchMaker(4, 3);

            //foreach (var item in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            //{
            //    Player player = new Player();
            //    player.FirstName = "- " + item.ToString();
            //    playerList.Add(player);
            //}

            //mm.StartGame();
        }

        public List<Player> GetPlayers()
        {
            return playerList;

        }
    }
}