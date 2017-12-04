using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Match : ModelBase
    {

        public ObservableCollection<Player> PlayersInMatch { get; set; }
        public int Id { get; set; }

        public Match()
        {
            PlayersInMatch = new ObservableCollection<Player>();
            Id = IdService.Instance.GetNewId();
        }
    }
}
