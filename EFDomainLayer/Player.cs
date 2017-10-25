using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Player : IID
{
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //PhoneNr er en string da det er data der ikke skal laves udregninger på
        public string PhoneNr { get; set; }
        public int ID
        {
            get { return PlayerId; }

            set { PlayerId = value; }
        }

}
}
