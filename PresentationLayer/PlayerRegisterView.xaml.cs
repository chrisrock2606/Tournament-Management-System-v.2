using System.Collections.ObjectModel;
using System.Windows;
using BusinessLayer;
using DomainLayer;
using System.Windows.Input;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerView.xaml
    /// </summary>
    public partial class PlayerRegisterView : Window
    {
        private ObservableCollection<Player> PlayerList;
        public PlayerRegisterView()
        {
            InitializeComponent();
            PlayerList = new ObservableCollection<Player>();
            PlayerList = BusinessFacade.GetPlayerData();
            PlayerDataGrid.ItemsSource = PlayerList;
        }

        private void btn_AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            AddPlayerWindow APW = new AddPlayerWindow();
            APW.ShowDialog();
            PlayerList = BusinessFacade.GetPlayerData();
            PlayerDataGrid.ItemsSource = null;
            PlayerDataGrid.ItemsSource = PlayerList;
        }

        private void btn_ViewLeagues_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }
        private void PlayerDataGrid_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            PlayerOverviewView POV = new PlayerOverviewView((Player)PlayerDataGrid.CurrentItem);
            this.Hide();
            POV.ShowDialog();
            this.Show();
        }
    }
}