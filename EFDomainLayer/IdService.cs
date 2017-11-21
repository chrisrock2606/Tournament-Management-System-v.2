using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDomainLayer
{
    class IdService
    {
        private int id;

        private static IdService instance;
        public static IdService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new IdService();
                }
                return instance;
            }
        }

        public int GetNewId()
        {
            id += id++;
            return id;
        }
    }
}
