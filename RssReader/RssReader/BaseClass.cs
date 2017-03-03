using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL;

namespace PL
{
    class BaseClass
    {
        private IBL bl;
        public BaseClass()
        {
            bl = Factory.getFactoryBL();
        }

        protected IBL Bl
        {
            get
            {
                return bl;
            }
        }
    }
}
