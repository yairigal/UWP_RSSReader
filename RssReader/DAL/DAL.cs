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
                Value = title
            };

            var searchRequest = new SearchRequest
            {
                Query = query
            };

            var result =  client.Search<RSSObject>(searchRequest);
            return result.Documents.ToList();
        }

        public bool saveRSS(RSSObject obj)
        {
            try
            {
                client.Index(obj);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public List<RSSObject> getListFromFeed()
        {
            return XmlHandler.getFeed(XmlHandler.YnetLink);
        }
    }
}
