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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PresentationLayer.ViewModels;
using System.Collections.ObjectModel;
using DomainLayer;
using Xceed.Wpf.AvalonDock.Layout;

namespace PresentationLayer.Views
{
    /// <summary>
    /// Interaction logic for PlayView.xaml
    /// </summary>
    public partial class PlayView : UserControl
    {
        public PlayView()
        {
            InitializeComponent();


            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (MainVM.Instance.SelectedTournament != null)
            {
                foreach (var item in MainVM.Instance.SelectedTournament.Rounds)
                {
                    StackPanel stack = new StackPanel();
                    TextBlock text = new TextBlock();
                    text.Text = item.RoundName;
                    stack.Children.Add(text);

                    foreach (var match in item.Matches)
                    {
                        StackPanel stack12 = new StackPanel();
                        stack12.Orientation = Orientation.Horizontal;
                        TextBlock matchId = new TextBlock();
                        matchId.Text = match.Id.ToString();
                        stack12.Children.Add(matchId);

                        foreach (var player in match.PlayersInMatch)
                        {
                            StackPanel stack13 = new StackPanel();
                            TextBlock playerName = new TextBlock();
                            playerName.Text = player.FirstName + " " + player.LastName;
                            stack13.Children.Add(playerName);
                            stack12.Children.Add(stack13);
                        }
                        stack.Children.Add(stack12);
                    }
                    stack1.Children.Add(stack);
                }
            }
        }
        
        
    }
}
