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
    static class XmlHandler
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
                {
                    lst.Add(new RSSObject(rss.Title.Text, rss.Summary.Text.getDescription(), rss.Id, null,
                        rss.PublishedDate.DateTime.extractDate(), rss.LastUpdatedTime.DateTime.extractDate(),rss.Summary.Text.getPicUri()));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }


            return lst;
        }

        public static string extractDate(this DateTime date)
        {
            return string.Format("{0},{1} {2} {3} {4}", date.DayOfWeek, date.Day, getMonth(date.Month),date.Year,date.TimeOfDay);
        }

        public static string getMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "Jan";
                case 2:
                    return "Feb";
                case 3:
                    return "Mar";
                case 4:
                    return "Apr";
                case 5:
                    return "May";               
                case 6:
                    return "Jun";
                case 7:
                    return "Jul";
                case 8:
                    return "Aug";
                case 9:
                    return "Sep";
                case 10:
                    return "Oct";
                case 11:
                    return "Nov";
                default:
                    return "Dec";
            }
        }

        public static string getPicUri(this string html)
        {
            string str = html;
            var patr = @"(src=.*\.jpg)";
            var pattern = @"(\|(?:.*?)\|)";
            return System.Text.RegularExpressions.Regex.Split(str, patr)[1].Substring(5);
        }

        public static string getDescription(this string html)
        {
            var ptr = @"(</div>.*)";
            string test = System.Text.RegularExpressions.Regex.Split(html, ptr)[1];
            return test.Substring(6);
        }
    }
}
