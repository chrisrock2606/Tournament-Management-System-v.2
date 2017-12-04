using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using EFDomainLayer;

namespace MatchmakingPrototype2
{
    static class Program
    {
        public static List<Player> playerList = new List<Player>();

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

            Tournament tournament = new Tournament();
            Round round = new Round();
            foreach (var player in playerList)
                round.PlayersInRound.Add(player);

            MatchMaker mm = new MatchMaker(4, 4, round);
            tournament.Rounds.Add(round);

            TournamentRepository.Instance.TournamentList.Add(tournament);

            mm.AddPlayersToMatches();

            Write();
        }

        static void Write()
        {

            foreach (var tournament in TournamentRepository.Instance.TournamentList)
            {
                foreach (var round in tournament.Rounds)
                {
                    Console.WriteLine("Runde: " + round.Id);
                    foreach (var match in round.Matches)
                    {
                        Console.WriteLine("matchID: " + match.Id);
                        foreach (var player in match.PlayersInMatch)
                        {
                            Console.WriteLine(player.FirstName);
                        }
                    }
                }
                Console.ReadLine();
            }
        }
    }
}