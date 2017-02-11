using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseClass
    {
        IDAL dal;
        public BaseClass()
        {
            dal = Factory.getFactoryDAL();
        }
    }
}
