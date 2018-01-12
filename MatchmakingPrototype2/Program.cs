using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using EFDomainLayer;
using System.Collections.ObjectModel;
namespace MatchmakingPrototype2
{
    static class Program
    {
        public static ObservableCollection<Player> playerList = new ObservableCollection<Player>();

        static void Main(string[] args)
        {
            Run();
        }

        static private void Run()
        {
            foreach (var item in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            {
                Player player = new Player();
                player.FirstName = "- " + item.ToString();
                playerList.Add(player);
            }

            MatchMaker mm = new MatchMaker(4, 3, playerList, new Tournament());

            Round round = mm.GetNewRound();


            Write(round);

            if (mm.PlayersImpossibleToGroupInRound.Count > 0)
            {
                Console.WriteLine("\n players not in matchgroups: ");
                foreach (var item in mm.PlayersImpossibleToGroupInRound)
                {
                    Console.WriteLine(item.FirstName);
                }
            }

            Console.ReadLine();
            Run();
        }

        static void Write(Round round)
        {


                foreach (var match in round.Matches)
                {
                Console.WriteLine("matchID: " + match.Id);

                foreach (var player in match.PlayersInMatch)
                    {
                    Console.WriteLine(player.FirstName);
                        
                    }
                }
            }
    }
}