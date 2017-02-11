using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDAL
    {
        //CRUD = create , read , update , delete
        //read
        RSSObject getRss();
        //create
        bool saveRSS(RSSObject obj);

        bool deleteRSS(RSSObject obj);

    }
}
