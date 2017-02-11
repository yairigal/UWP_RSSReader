using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Factory
    {
        static IDAL instance = null;
        public static Func<IDAL> factory = getDAL;
        public static IDAL getFactoryDAL()
        {
            if (instance == null)
                instance = factory();
            return instance;
        }

        static IDAL getDAL()
        {
            return new DAL();
        }
    }
}
