using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BusinessLayer;
using DomainLayer;

// ReSharper disable PossibleInvalidOperationException

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for AddLeagueWindow.xaml
    /// </summary>
    public partial class AddLeagueWindow : Window
    {
        public AddLeagueWindow()
        {
            InitializeComponent();
            cb_Rounds.SelectedIndex = 0;
            DisableUnusedTextboxes();
            rb_OneTeamMember.IsChecked = true;
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<TextBox> collection = addLeagueWindow.Children.OfType<TextBox>();
            foreach (var item in collection)
            {
                item.Text = "";
            }
            rb_OneTeamMember.IsChecked = true;
            cb_Rounds.SelectedIndex = 0;
        }

        private void btn_SaveLeague_Click(object sender, RoutedEventArgs e)
        {
            League newLeague = new League();
            newLeague.GameName = txt_GameName.Text;
            newLeague.LeagueName = txt_LeagueName.Text;
            newLeague.Reward = txt_Reward.Text;
            newLeague.LeagueStatus = "Afventende";
            //removes unwanted words from ComboBoxItem. uses space to go to the start of the word needed
            newLeague.LeagueStatus =
                newLeague.LeagueStatus.Substring(newLeague.LeagueStatus.IndexOf(" ", StringComparison.Ordinal) + 1);
            newLeague.Rounds = cb_Rounds.SelectedIndex + 1;
            IEnumerable<RadioButton> rb_collection = addLeagueWindow.Children.OfType<RadioButton>();
            newLeague.LeagueId = BusinessFacade.SaveLeague(newLeague);
            IEnumerable<TextBox> tb_collection = addLeagueWindow.Children.OfType<TextBox>();
            foreach (var item in tb_collection)
            {
                if (item.Name.Contains("Round"))
                {
                    if (item.IsEnabled)
                    {
                        Round newRound = new Round();
                        newRound.RoundName = item.Text;
                        BusinessFacade.SaveRound(newRound, newLeague.LeagueId);
                    }
                }
            }
            this.Owner.Show();
            this.Close();
        }

        private void cb_Rounds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisableUnusedTextboxes();
        }

        private void DisableUnusedTextboxes()
        {
            IEnumerable<TextBox> tb_collection = addLeagueWindow.Children.OfType<TextBox>();
            foreach (var item in tb_collection)
            {
                if (item.Name.Contains("Round"))
                {
                    item.IsEnabled = false;
                }
            }
            for (int i = 0; i < cb_Rounds.SelectedIndex + 1; i++)
            {
                foreach (var item in tb_collection)
                {
                    if (item.Name.Contains($"Round{i + 1}"))
                    {
                        item.IsEnabled = true;
                    }
                    else if (item.Name.Contains("Round"))
                    {
                        item.Text = "";
                    }
                }
            }
        }
    }
}