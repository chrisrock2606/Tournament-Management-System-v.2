using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Input;

namespace PresentationLayer.ViewModels
{
    public class PlayerVM : ModelBase
    {

#region Properties
        public ICommand CommandCreatePlayer { get; set; }
        public ICommand CommandDeletePlayer { get; set; }


    private ObservableCollection<Player> players;
    public ObservableCollection<Player> Players
        {
            get { return players; }
            set
            {
                if (value != players)
                {
                    players = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Player selectedPlayer;

        public Player SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                if (value != selectedPlayer)
                {
                    selectedPlayer = value;
                    NotifyPropertyChanged();
                }
            }
        }

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
                    if (SelectedTournament.Players != null)
                    {
                        Players = SelectedTournament.Players;
                    }
                }
            }
        }
        #endregion

        public PlayerVM()
        {
            CommandCreatePlayer = new Command(ExecuteCommandCreatePlayer, CanExecuteCommandCreatePlayer);
            CommandDeletePlayer = new Command(ExecuteCommandDeletePlayer, CanExecuteCommandDeletePlayer);
        }

#region Commands

        private bool CanExecuteCommandCreatePlayer(object parameter)
        {
            return false;
        }
        private void ExecuteCommandCreatePlayer(object parameter)
        {
        }

        private bool CanExecuteCommandDeletePlayer(object parameter)
        {
            if (SelectedPlayer != null && SelectedTournament != null)
            {
                return true;
            }
            return false;
        }
        private void ExecuteCommandDeletePlayer(object parameter)
        {
            if (SelectedPlayer != null && SelectedTournament != null)
            {
                if (SelectedTournament.Players.Contains(SelectedPlayer))
                    SelectedTournament.Players.Remove(SelectedPlayer);
            }
        }

#endregion



    }
}
