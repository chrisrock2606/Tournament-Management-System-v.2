using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool PropertyDataChanged { get; set; }

        // The CallerMemberName Attribute below is new to .NET Framework 4.5. It determines the calling property name automatically!
        protected void NotifyPropertyChanged([CallerMemberName] String property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
                PropertyDataChanged = true;
            }
        }
    }
}