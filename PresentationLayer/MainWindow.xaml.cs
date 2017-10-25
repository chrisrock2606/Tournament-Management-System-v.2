using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLayer;
using DomainLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<League> LeagueList;
        public MainWindow()
        {
            InitializeComponent();
            RefreshGrid();
        }

        private void btn_AddLeague_Click(object sender, RoutedEventArgs e)
        {
            AddLeagueWindow ALW = new AddLeagueWindow();
            this.Hide();
            ALW.Owner = this;
            ALW.ShowDialog();
            RefreshGrid();
        }

        private void grid_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            LeagueOverviewView LOV = new LeagueOverviewView((League)LeagueDataGrid.CurrentItem);
            this.Hide();
            LOV.Owner = this;
            LOV.ShowDialog();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            LeagueList = BusinessFacade.GetLeagueData();
            LeagueDataGrid.ItemsSource = null;
            LeagueDataGrid.ItemsSource = LeagueList;
        }

        private void btn_ViewPlayers_Click(object sender, RoutedEventArgs e)
        {
            PlayerRegisterView PV = new PlayerRegisterView();
            PV.Show();
            this.Close();
        }
    }
}