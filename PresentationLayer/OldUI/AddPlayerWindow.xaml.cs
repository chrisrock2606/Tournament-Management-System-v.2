using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BusinessLayer;
using DomainLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for AddPlayerWindow.xaml
    /// </summary>
    public partial class AddPlayerWindow : Window
    {
        public AddPlayerWindow()
        {
            InitializeComponent();
            btn_AddPlayer.IsEnabled = false;
        }

        private void btn_AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Player newPlayer = new Player();
            newPlayer.FirstName = txt_FirstName.Text;
            newPlayer.LastName = txt_LastName.Text;
            newPlayer.Email = txt_Email.Text;
            newPlayer.PhoneNr = txt_PhoneNr.Text;
            BusinessFacade.SavePlayer(newPlayer);
            this.Close();
        }

        private void Txt_FirstName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            DoEveryTextboxContainText();
        }

        private void Txt_LastName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            DoEveryTextboxContainText();
        }

        private void Txt_PhoneNr_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            
            if (txt_PhoneNr.Text != "")
            {
                //ensures that only numbers are entered
                if (!int.TryParse(txt_PhoneNr.Text, out i))
                {
                    //Removes the last letter
                    txt_PhoneNr.Text = txt_PhoneNr.Text.Remove(txt_PhoneNr.Text.Length - 1);
                    MessageBox.Show("Indtast kun tal");
                }
            }
            DoEveryTextboxContainText();
        }

        private void Txt_Email_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            DoEveryTextboxContainText();
        }

        private void DoEveryTextboxContainText()
        {
            if (!string.IsNullOrWhiteSpace(txt_FirstName.Text) && !string.IsNullOrWhiteSpace(txt_LastName.Text) && !string.IsNullOrWhiteSpace(txt_PhoneNr.Text) && !string.IsNullOrWhiteSpace(txt_Email.Text))
            {
                btn_AddPlayer.IsEnabled = true;
            }
            else
            {
                btn_AddPlayer.IsEnabled = false;
            }
        }
    }
}
