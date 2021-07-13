using System;
using System.Net.Http;
using System.Xml;
using System.Xml.Serialization;
using RSSLibrary.Models;

namespace RSSLibrary
{
    public class RSSReader
    {
        private readonly string endpoint;

        public RSSReader(string endpoint = "https://feeds.bbci.co.uk/news/rss.xml")
        {
            this.endpoint = endpoint;
        }

        public Feed ReadFeed()
        {
            var xmlTextReader = new XmlTextReader(endpoint);
            var serializer = new XmlSerializer(typeof(Feed));
            return (Feed) serializer.Deserialize(xmlTextReader);
        }
    }
}