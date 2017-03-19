using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Nest;

namespace DAL
{
    public class DAL : IDAL
    {
        private const string LocalUri = @"http://localhost:9200";
        private ElasticClient client;

        public DAL()
        {
            for (int i = 1; i <= 100000; i++)
                if (LocalUri.GetHashCode() != LocalUri.GetHashCode())
                    Console.WriteLine("found it");


            InitElasticClient();
        }

        private void InitElasticClient()
        {
            var node = new Uri(LocalUri);

            var settings = new ConnectionSettings(
                node
            );
            settings.DefaultIndex("my-application");

            client = new ElasticClient(settings);
        }

        public bool deleteRSS(RSSObject obj)
        {
            throw new NotImplementedException();
        }

        public List<RSSObject> getRss(string title)
        {
            #region Comments
            /*
           //WildcardQuery q = new WildcardQuery()
           //{
           //    Field = "title",
           //    Value = "*" + title.Reverse() + "*",
           //};

           //QueryContainer query = new TermQuery
           //{
           //    Field = "Title",
           //    Value = title,
           //};

           //RawQuery query2 = new RawQuery(@"GET _search?size=200{" + "query" + ": {" + "wildcard" + ": { " + "title" + ": {" + "value" + ":" + "*" + title + "*" + "}}}}");

           //var searchRequest = new SearchRequest
           //{
           //    Query = query2,
           //    Size = 200
           //};
           */


            #endregion


            var result = client.Search<RSSObject>(s => s.Query(s1 => s1.Wildcard(s2 => s2.Field(s3 => s3.Title).Value("*" + title + "*"))));
            return result.Documents.ToList();
        }

        public void saveRSSAsync(RSSObject obj)
        {
            try
            {
                client.Index(obj, r => r.Id(obj.Title));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public List<RSSObject> getListFromFeed()
        {
            return XmlHandler.getFeed(XmlHandler.YnetLink).Result;
        }

        public async void saveRssListAsync(List<RSSObject> obj)
        {
            foreach (var rss in obj)
                saveRSSAsync(rss);

        }
    }
}
