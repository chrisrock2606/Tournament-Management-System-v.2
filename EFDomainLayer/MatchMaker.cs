using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DomainLayer;

namespace DomainLayer
{
    public class MatchMaker
    {
        public int MaxPlayersInMatch { get; private set; }
        public int MinPlayersInMatch { get; private set; }
        public ObservableCollection<Player> Players { get; private set; }
        public Round Round { get; private set; }

        public ObservableCollection<Player> PlayersCompetedInPreviousRound { get; private set; }
        public ObservableCollection<Player> PlayersImpossibleToGroupInRound { get; private set;}

        public MatchMaker(int maxPlayersInMatch, int minPlayersInMatch, ObservableCollection<Player> players)
        {
            PlayersCompetedInPreviousRound = new ObservableCollection<Player>();
            PlayersImpossibleToGroupInRound = new ObservableCollection<Player>();

            this.MaxPlayersInMatch = maxPlayersInMatch;
            this.MinPlayersInMatch = minPlayersInMatch;
            this.Players = players;

        }
        public Round GetNewRound()
        {
            Round = new Round();

            AddPlayersToMatches();
            return Round;
        }   

        public void AddPlayersToMatches()
        {
            CreateNewMatches();

            foreach (var player in Players)
            {
                foreach (var match in Round.Matches.Where(x => x.PlayersInMatch.Count < MaxPlayersInMatch))
                {
                    if (match.PlayersInMatch.Count == 0 || CheckIfCompetedBefore(player, match) == false)
                    {
                        player.MatchIdValues.Add(match.Id);
                        match.PlayersInMatch.Add(player);
                        break;
                    }

                    else if (CheckIfCompetedBefore(player, match) == true)
                    {
                        PlayersCompetedInPreviousRound.Add(player);
                        break;
                    }
                }
            }
            CheckIfMatchesAreTooSmall();
        }

        public ObservableCollection<Match> CreateNewMatches()
        {
            int numberOfMatchesToCreate = Players.Count / MaxPlayersInMatch;
            if (Players.Count % MaxPlayersInMatch != 0)
                numberOfMatchesToCreate += 1;

            for (int i = 0; i < numberOfMatchesToCreate; i++)
            {
                Match match = new Match();
                Round.Matches.Add(match);
            }
            return Round.Matches;
        }

        private void CheckIfMatchesAreTooSmall()
        {
            foreach (var match in Round.Matches.Where(m => m.PlayersInMatch.Count < MinPlayersInMatch))
            {
                foreach (var fullMatch in Round.Matches.Where(x => x.PlayersInMatch.Count == MaxPlayersInMatch && x.PlayersInMatch.Count - 1 > MinPlayersInMatch))
                {
                    var participant = fullMatch.PlayersInMatch[0];
                    fullMatch.PlayersInMatch.Remove(participant);

                    match.PlayersInMatch.Add(participant);
                    break;
                }
            }
            FindPlayersImpossibleToGroupInRound();
        }

        private void FindPlayersImpossibleToGroupInRound()
        {

            for (int i = 0; i < Round.Matches.Count; i++)
            {
                if (Round.Matches[i].PlayersInMatch.Count < MinPlayersInMatch)
                {
                    foreach (var player in Round.Matches[i].PlayersInMatch)
                    {
                        PlayersImpossibleToGroupInRound.Add(player);
                    }
                    Round.Matches.Remove(Round.Matches[i]);
                }
            }
        }

        private void HandleParticipantsInConflict(List<Player> participantsInConflict)
        {
            foreach (var participant in participantsInConflict)
            {
                int matchSize = 0;
                foreach (var match in Round.Matches)
                {
                    if (match.PlayersInMatch.Count == matchSize)
                    {
                        match.PlayersInMatch.Add(participant);
                        break;
                    }
                    matchSize++;
                }
            }
        }

        private bool CheckIfCompetedBefore(Player player, Match match)
        {
            foreach (var competitor in match.PlayersInMatch)
            {
                var matchingIDs = player.MatchIdValues.Intersect(competitor.MatchIdValues);
                if (matchingIDs.Count() > 0)
                    return true;
            }
            return false;            
        }
    }
}