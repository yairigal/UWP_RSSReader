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


        public RSSObject(string title = "",string des = "",string link = "" ,List<String> tags = null)
        {
            this.title = title;
            this.description = des;
            this.link = link;
            if (tags == null)
                this.tags = new List<string>();
            else
                this.tags = tags;
        }
    }
}
