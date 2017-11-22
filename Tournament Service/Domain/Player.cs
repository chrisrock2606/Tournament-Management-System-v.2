using System.ComponentModel;
using System.Runtime.Serialization;

namespace Domain
{
    [DataContract]
    public class Player : INotifyPropertyChanged, IID
    {
        private int playerId;
        private string firstName;
        private string lastName;
        private string userName;
        private string email;
        private string phoneNr;
        [DataMember]
        public int PlayerId
        {
            get { return playerId; }
            set
            {
                if (playerId != value)
                {
                    playerId = value;
                    RaisePropertyChanged("PlayerId");
                }
            }
        }
        [DataMember]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    RaisePropertyChanged("FirstName");
                }
            }
        }
        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    RaisePropertyChanged("UserName");
                }
            }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    RaisePropertyChanged("Email");
                }
            }
        }
        //PhoneNr er en string da det er data der ikke skal laves udregninger på
        [DataMember]
        public string PhoneNr
        {
            get { return phoneNr; }
            set
            {
                if (phoneNr != value)
                {
                    phoneNr = value;
                    RaisePropertyChanged("PhoneNr");
                }
            }
        }
        [DataMember]
        public int ID
        {
            get { return PlayerId; }

            set { PlayerId = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
