using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace PL
{
    public class BaseClass
    {
        protected IDAL dal;
        public BaseClass()
        {
            dal = DAL.Factory.getFactoryDAL();
        }
    }
}
