using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace PresentationLayer.ViewModels
{
    class MainVM : ModelBase
    {
        private static MainVM instance;
        private Tournament selectedTournament;

        public Tournament SelectedTournament
        {
            get { return selectedTournament; }
            set
            {
                if (value != selectedTournament)
                {
                    selectedTournament = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string tournamentName;

        public string TournamentName
        {
            get { return tournamentName; }
            set
            {
                if (value != tournamentName)
                {
                    tournamentName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public static MainVM Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainVM();
                }
                return instance;
            }
        }
        public MainVM()
        {
        }
    }
}
