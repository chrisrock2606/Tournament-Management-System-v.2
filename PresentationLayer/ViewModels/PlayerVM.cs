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
        public ICommand CommandCreatePlayer { get; set; }
        public ICommand CommandDeletePlayer { get; set; }
        public ICommand CommandClearTextBoxes { get; set; }

        #region properties

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

                    if (SelectedPlayer != null)
                    {
                        PlayerFirstName = SelectedPlayer.FirstName;
                        PlayerLastName = SelectedPlayer.LastName;
                        PlayerUserName = SelectedPlayer.UserName;
                        PlayerEmail = SelectedPlayer.Email;
                    }
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

        private string playerFirstName;
        public string PlayerFirstName
        {
            get { return playerFirstName; }
            set
            {

                if (value != playerFirstName)
                {
                    playerFirstName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string playerLastName;
        public string PlayerLastName
        {
            get { return playerLastName; }
            set
            {

                if (value != playerLastName)
                {
                    playerLastName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string playerUserName;
        public string PlayerUserName
        {
            get { return playerUserName; }
            set
            {

                if (value != playerUserName)
                {
                    playerUserName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string playerEmail;
        public string PlayerEmail
        {
            get { return playerEmail; }
            set
            {

                if (value != playerEmail)
                {
                    playerEmail = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        public PlayerVM()
        {
            CommandCreatePlayer = new Command(ExecuteCommandCreatePlayer, CanExecuteCommandCreatePlayer);
            CommandDeletePlayer = new Command(ExecuteCommandDeletePlayer, CanExecuteCommandDeletePlayer);
            CommandClearTextBoxes = new Command(ExecuteCommandClearTextBoxes, CanExecuteCommandClearTextBoxes);
        }

        #region Commands

        private bool CanExecuteCommandCreatePlayer(object parameter)
        {
            if (PlayerFirstName != null && MainVM.Instance.SelectedTournament != null)
                return true;

            return false;
        }
        private void ExecuteCommandCreatePlayer(object parameter)
        {
            Player player = new Player();
            player.FirstName = PlayerFirstName;
            player.LastName = PlayerLastName;
            player.UserName = PlayerUserName;
            player.Email = PlayerEmail;
            player.Id = IdService.Instance.GetNewId();

            MainVM.Instance.SelectedTournament.Players.Add(player);
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

        private bool CanExecuteCommandClearTextBoxes(object parameter)
        {
            return true;
        }
        private void ExecuteCommandClearTextBoxes(object parameter)
        {
            PlayerFirstName = null;
            PlayerLastName = null;
            PlayerUserName = null;
            PlayerEmail = null;
        }

        #endregion
    }
}
