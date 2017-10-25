using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainLayer;

namespace BusinessLayer
{
    class MatchMaker
    {
        private static Random rng = new Random();

        //ShuffleTeams blander placeringen af holdende i listen TeamList ved at bytte på placeringen af 2 hold af gangen
        public ObservableCollection<Team> ShuffleTeams(ObservableCollection<Team> TeamList)
        {
            int n = TeamList.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n);

                // får value til at holde det hold der er på k pladsen i listen af hold (TeamList)
                Team value = TeamList[k];
                // på den plads hvor holdNr k ligger sættes holdNr n ind på i stedet
                TeamList[k] = TeamList[n];
                //på den plads hvor holdNr n ligger sættes holdNr k in i stedet
                TeamList[n] = value;

            }
            return TeamList;
        }

        public ObservableCollection<Round> CreateMatches(ObservableCollection<Team> TeamsInLeague, ObservableCollection<Round> RoundsInLeague)
        {
            ObservableCollection<Round> result = new ObservableCollection<Round>();

            //listen af hold blandes
            TeamsInLeague = ShuffleTeams(TeamsInLeague);

            // antal af kampe der skal være i en runde er = antallet af hold delt med 2
            int numberOfMatchesInARound = TeamsInLeague.Count / 2;

            List<Team> teams = new List<Team>();

            //tager listen af hold og springer halvdelen over og tilføjer den sidste halvdel til listen Teams
            teams.AddRange(TeamsInLeague.Skip(numberOfMatchesInARound).Take(numberOfMatchesInARound));

            //springer det første hold over og tilføjer holdende derfra og optil halvvejen -1, 
            //ligger dem ind i et array derefter vender arrayet rundt og tilføjer arrayet til listen Team
            teams.AddRange(TeamsInLeague.Skip(1).Take(numberOfMatchesInARound - 1).ToArray().Reverse());
            
            var numberOfTeams = teams.Count;

            // kører for hvert antal af runde objekter i listen af RoundsInLeague
            for (var roundNumber = 0; roundNumber < RoundsInLeague.Count; roundNumber++)
            {
                
                var teamIdx = roundNumber % numberOfTeams;
                Match newMatch = new Match();

                //newMatch indeholder en liste af hold
                //tager det hold som er på tallet TeamIdx i teams listen 
                //og tilføjer det til listen TeamsInMatch
                newMatch.TeamsInMatch.Add(teams[teamIdx]);

                //tager derefter det hold som ligger først i listen TeamsInLeague
                //som vi sprang over før og tilføjer det til listen TeamsInMatch
                newMatch.TeamsInMatch.Add(TeamsInLeague[0]);

                //Gemmer den Match som lige er blevet lavet til databasen
                DataAccessFacade.SaveMatch(newMatch, RoundsInLeague[roundNumber].RoundId);

                //tilføjer den Match der lige er blevet lavet 
                //til listen af kampe i en given runde
                RoundsInLeague[roundNumber].MatchesInRound.Add(newMatch);

                //kører for hver Match der skal være i Round
                for (var idx = 1; idx < numberOfMatchesInARound; idx++)
                {
                    //en variabel der holder på et nummer der skal endikere 
                    //det første hold den tager i en match
                    var firstTeamIndex = (roundNumber + idx) % numberOfTeams;

                    //en variabel der endikere det andet hold der skal der skal i en match
                    var secondTeamIndex = (roundNumber + numberOfTeams - idx) % numberOfTeams;

                    Match newMatch2 = new Match();

                    //tilføjer det første hold til en match
                    newMatch2.TeamsInMatch.Add(teams[firstTeamIndex]);

                    //endikere det andet hold der skal i en match
                    newMatch2.TeamsInMatch.Add(teams[secondTeamIndex]);

                    //gemmer match info på database
                    DataAccessFacade.SaveMatch(newMatch2, RoundsInLeague[roundNumber].RoundId);

                    //gemmer match til listen af matches på en specifik round
                    RoundsInLeague[roundNumber].MatchesInRound.Add(newMatch2);
                }

                // tilføjer runden til en liste af runder
                result.Add(RoundsInLeague[roundNumber]);
            }
            //returnere listen af runder
            return result;
        }
    }
}
