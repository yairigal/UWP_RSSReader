using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Data.Xml.Dom;
using Windows.Web.Syndication;
using BE;

namespace DAL
{
    class XmlHandler
    {
        public const string YnetLink = "http://www.ynet.co.il/Integration/StoryRss2.xml";
        public const string testLink = "http://www.feedforall.com/sample.xml";

        public static List<RSSObject> getFeed(string link)
        {
            List<RSSObject> lst = new List<RSSObject>();
            //SyndicationFeed feed = null;
            try
            {
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            //foreach (var rss in feed.Items)        
            //    lst.Add(new RSSObject(rss.Title.ToString(),rss.Summary.ToString(),rss.ItemUri.ToString(),null));

            return lst;
        }
    }
}
