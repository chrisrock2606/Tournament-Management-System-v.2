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

namespace PresentationLayer.Views
{
    /// <summary>
    /// Interaction logic for Brackets.xaml
    /// </summary>
    public partial class Brackets : Window
    {
        public Brackets()
        {
            InitializeComponent();

            Image img = new Image();
            img.Source = new BitmapImage(new Uri(@"C:\Users\mail\Desktop\visio-final-four-bracket-2011-visio-insights.png"));

            StackPanel stackPnl = new StackPanel();
            stackPnl.Orientation = Orientation.Horizontal;
            stackPnl.Margin = new Thickness(10);
            stackPnl.Children.Add(img);
        }
    }
}
