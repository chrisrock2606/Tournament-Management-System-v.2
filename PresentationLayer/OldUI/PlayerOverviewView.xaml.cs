using System;
using System.Collections.Generic;
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
using DomainLayer;
using BusinessLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerOverviewView.xaml
    /// </summary>
    public partial class PlayerOverviewView : Window
    {

        Player ChosenPlayer;
        public PlayerOverviewView(Player chosenPlayer)
        {
            InitializeComponent();
            ChosenPlayer = chosenPlayer;
            lbl_CurrentPlayerId.Content = chosenPlayer.PlayerId;
            txt_FirstName.Text = chosenPlayer.FirstName;
            txt_LastName.Text = chosenPlayer.LastName;
            txt_Email.Text = chosenPlayer.Email;
            txt_PhoneNr.Text = chosenPlayer.PhoneNr;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            ChosenPlayer.FirstName = txt_FirstName.Text;
            ChosenPlayer.LastName = txt_LastName.Text;
            ChosenPlayer.Email = txt_Email.Text;
            ChosenPlayer.PhoneNr = txt_PhoneNr.Text;

            BusinessFacade.UpdatePlayer(ChosenPlayer);

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            BusinessFacade.DeletePlayer(ChosenPlayer);
        }
    }
}
