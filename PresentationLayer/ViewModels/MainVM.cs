using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace PresentationLayer.ViewModels
{
    class MainVM
    {
        public ObservableCollection<Tournament> TournamentList { get; set; }

        public MainVM()
        {
            TournamentList = TournamentRepository.Instance.TournamentList;
        }
    }
}
