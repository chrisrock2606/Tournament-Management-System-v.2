﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace DomainLayer
{
    public class TournamentRepository
    {
        private static TournamentRepository instance;
        public ObservableCollection<Tournament> TournamentList;

        private TournamentRepository()
        {
            TournamentList = new ObservableCollection<Tournament>();
        }

        public static TournamentRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TournamentRepository();
                }
                return instance;
            }
        }

        public void AddTournamentToList(Tournament newTournament)
        {
            TournamentList.Add(newTournament);
        }

        public void AddTournamentToList(string newTournamentName, string newGameName)
        {
            Tournament newTournament = new Tournament() {GameName = newGameName, TournamentName = newTournamentName};
            TournamentList.Add(newTournament);
        }
    }
}