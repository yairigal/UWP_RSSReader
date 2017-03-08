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
            QueryContainer query = new TermQuery
            {
                Field = "Title",
                Value = title,
            };

            var searchRequest = new SearchRequest
            {
                Query = query,
                From = 100,
            };

            var result =  client.Search<RSSObject>(searchRequest);
            return result.Documents.ToList();
        }

        public void saveRSSAsync(RSSObject obj)
        {
            try
            {
                client.IndexAsync(obj);
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
    }
}
