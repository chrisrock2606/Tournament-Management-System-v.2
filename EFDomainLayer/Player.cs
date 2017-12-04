using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Player : ModelBase
    {
        private string firstName;
        private string lastName;
        private string userName;
        private string email;
        private bool defeated;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool Defeated
        {
            get { return defeated; }
            set
            {
                if (defeated != value)
                {
                    defeated = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int Id { get; set; }

        public List<int> MatchIdValues { get; set; }

        public Player()
        {
            MatchIdValues = new List<int>();
            Id = IdService.Instance.GetNewId();
        }

    }
}
