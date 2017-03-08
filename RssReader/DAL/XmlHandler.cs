using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Web.Syndication;
using BE;
using Elasticsearch.Net;

namespace DAL
{
    class XmlHandler
    {
        public const string YnetLink = "http://www.ynet.co.il/Integration/StoryRss2.xml";
        public const string testLink = "http://www.feedforall.com/sample.xml";

        public static async Task<List<RSSObject>> getFeed(string link)
        {
            List<RSSObject> lst = new List<RSSObject>();
            IAsyncOperationWithProgress<SyndicationFeed, RetrievalProgress> feed = null;
            try
            {
                Uri uri = new Uri(YnetLink);
                //Task tsk = new Task(async ()=>feed = await );
                feed = Task.Run(() => new SyndicationClient().RetrieveFeedAsync(uri)).Result;
                while (feed.Status != AsyncStatus.Completed);
                foreach (var rss in feed.GetResults().Items)
                    lst.Add(new RSSObject(rss.Title.Text, rss.Summary.Text, rss.Id, null));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }


            return lst;
        }
    }
}
