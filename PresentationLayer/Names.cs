using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public static class Names
    {
        public static List<string> FirstNames { get; set; }
        public static List<string> LastNames { get; set; }

        static public void GetNames()
        {
            var stringsss = Properties.Resources.Hispanic_Female_Names;
            string[] arr = Properties.Resources.Hispanic_Female_Names.Split('\n');

            FirstNames = new List<string>();
            LastNames = new List<string>();

            for (int i = 1; i < 30; i++)
            {
                var names = arr[i].Split(',');
                FirstNames.Add(names[1].Trim());
                LastNames.Add(names[0]);
            }
        }
    }
}
