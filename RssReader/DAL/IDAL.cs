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
        List<RSSObject> getRss(string title);
        //create
        bool saveRSS(RSSObject obj);

        bool deleteRSS(RSSObject obj);

        List<RSSObject> getListFromFeed();

    }
}
