using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DomainLayer;

namespace EFDomainLayer
{
    class MatchMaker
    {
        public int MaxPlayersInMatch { get; }
        public int MinPlayersInMatch { get; }
        public ObservableCollection<Player> Players { get; }
        public Round Round { get; }

        ObservableCollection<Match> matches = new ObservableCollection<Match>();
        ObservableCollection<Player> playersCompetedInPreviousRound = new ObservableCollection<Player>();
        ObservableCollection<Player> playersImpossibleToGroupInRound = new ObservableCollection<Player>();


        TournamentRepository tournament = TournamentRepository.Instance;


        public MatchMaker(int maxPlayersInMatch, int minPlayersInMatch, Round round)
        {
            this.MaxPlayersInMatch = maxPlayersInMatch;
            this.MinPlayersInMatch = minPlayersInMatch;
            this.Players = round.PlayersInRound;
            this.Round = round;
        }

        public void AddPlayersToMatches()
        {
            foreach (var player in Players)
            {
                foreach (var match in matches.Where(x => x.PlayersInMatch.Count < MaxPlayersInMatch))
                {
                    if (match.PlayersInMatch.Count == 0 || CheckIfCompetedBefore(player, match) == false)
                    {
                        player.MatchIdValues.Add(match.ID);
                        match.PlayersInMatch.Add(player);
                        break;
                    }

                    else if (CheckIfCompetedBefore(player, match) == true)
                    {
                        playersCompetedInPreviousRound.Add(player);
                        break;
                    }
                }
            }
            CheckIfMatchesAreTooSmall();
        }

        private void CreateNewMatches()
        {
            int numberOfMatchesToCreate = Players.Count / MaxPlayersInMatch;
            if (Players.Count % MaxPlayersInMatch != 0)
                numberOfMatchesToCreate += 1;

            for (int i = 0; i < numberOfMatchesToCreate; i++)
            {
                Match match = new Match();
                match.ID = IdService.Instance.GetNewId();
                matches.Add(match);
            }
        }

        private void CheckIfMatchesAreTooSmall()
        {
            foreach (var match in matches)
            {
                if (match.PlayersInMatch.Count < MinPlayersInMatch && MaxPlayersInMatch != MinPlayersInMatch)
                {
                    foreach (var fullMatch in matches.Where(x => x.PlayersInMatch.Count == MaxPlayersInMatch))
                    {
                        var participant = fullMatch.PlayersInMatch[0];
                        fullMatch.PlayersInMatch.Remove(participant);

                        match.PlayersInMatch.Add(participant);
                        break;
                    }
                }
            }
            if (MaxPlayersInMatch == MinPlayersInMatch)
                PlayersImpossibleToGroupInRound();
        }

        private void PlayersImpossibleToGroupInRound()
        {
            foreach (var match in matches)
            {
                if (match.PlayersInMatch.Count < MinPlayersInMatch)
                    playersImpossibleToGroupInRound = match.PlayersInMatch;
            }
        }

        private void HandleParticipantsInConflict(List<Player> participantsInConflict)
        {
            foreach (var participant in participantsInConflict)
            {
                int matchSize = 0;
                foreach (var match in matches)
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