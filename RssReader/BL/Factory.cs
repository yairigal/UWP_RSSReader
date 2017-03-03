using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Factory
    {
        static IBL instance = null;
        public static Func<IBL> factory = getBL;
        public static IBL getFactoryBL()
        {
            if (instance == null)
                instance = factory();
            return instance;
        }

        static IBL getBL()
        {
            return new BL();
        }
    }
}
