using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLayer;
using DomainLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for AddPlayerToLeagueView.xaml
    /// </summary>
    public partial class AddPlayerToLeagueView : Window
    {
        private League ChosenLeague;

        public AddPlayerToLeagueView(League chosenLeague)
        {
            InitializeComponent();
            ObservableCollection<Player> playerList = new ObservableCollection<Player>();
            playerList = BusinessFacade.GetPlayerData();
            PlayerDataGrid.ItemsSource = playerList;
            ChosenLeague = chosenLeague;
        }

        private void grid_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            PlayerOverviewView POV = new PlayerOverviewView((Player)PlayerDataGrid.CurrentItem);
            this.Hide();
            POV.Owner = this;
            POV.ShowDialog();
        }

        private void btn_AddToLeague_Click(object sender, RoutedEventArgs e)
        {
            foreach (Player Item in PlayerDataGrid.SelectedItems)
            {
                if (!ChosenLeague.PlayersInLeague.Any(x => x.FirstName.Equals(Item.FirstName) && x.LastName.Equals(Item.LastName)))
                {
                    BusinessFacade.SavePlayer(Item);
                    ChosenLeague.PlayersInLeague.Add(Item);
                }
                else
                {
                    MessageBox.Show($"Spiller {Item.FirstName} {Item.LastName} eksisterer allerede i Ligaen");
                }
                
                
            }
            this.Owner.Show();
            this.Close();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
