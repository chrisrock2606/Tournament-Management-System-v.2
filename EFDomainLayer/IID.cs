using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    //vi bruger IID for at kunne samle alle ID'er under 1 metode
    public interface IID
    {
        int ID { get; set; }
    }
}
