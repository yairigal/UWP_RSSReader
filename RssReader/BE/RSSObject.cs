using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class RSSObject
    {
        string title;
        string description;
        string link;
        List<string> tags;
        private string publishedDate;
        private string lastUpdatedDate;
        private string PicUri;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Link
        {
            get
            {
                return link;
            }

            set
            {
                link = value;
            }
        }

        public List<string> Tags
        {
            get
            {
                return tags;
            }

            set
            {
                tags = value;
            }
        }

        public string PublishedDate
        {
            get
            {
                return publishedDate;
            }

            set
            {
                publishedDate = value;
            }
        }

        public string LastUpdatedDate
        {
            get
            {
                return lastUpdatedDate;
            }

            set
            {
                lastUpdatedDate = value;
            }
        }


        public string PicUri1
        {
            get
            {
                return PicUri;
            }

            set
            {
                PicUri = value;
            }
        }

        public RSSObject(string title = "",string des = "",string link = "" ,List<String> tags = null,string pub = "",string last = "",string pic = "")
        {
            this.title = title;
            this.description = des;
            this.link = link;
            if (tags == null)
                this.tags = new List<string>();
            else
                this.tags = tags;

            PublishedDate = pub;
            LastUpdatedDate = last;
            PicUri = pic;
        }
    }
}
