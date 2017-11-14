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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for RoundOverviewView.xaml
    /// </summary>
    public partial class RoundOverviewView : Window
    {
        public RoundOverviewView(Round chosenRound, string LeagueName, string GameName)
        {
            InitializeComponent();
            lbl_LeagueName.Content = LeagueName;
            lbl_GameName.Content = GameName;
            lbl_RoundName.Content = chosenRound.RoundName;
            MatchDataGrid.ItemsSource = chosenRound.MatchesInRound;
        }
    }
}
