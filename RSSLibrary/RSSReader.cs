using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using RSSLibrary.Models;

namespace RSSLibrary
{
    public class RSSReader
    {
        private readonly string endpoint;
        private XmlSerializer serializer = new XmlSerializer(typeof(Feed));

        public RSSReader(string endpoint = "https://feeds.bbci.co.uk/news/rss.xml")
        {
            this.endpoint = endpoint;
        }

        public async Task<Feed> ReadFeedAsync()
        {
            var httpClient = new HttpClient();
            var httpResponseMessage = await httpClient.GetAsync(endpoint);

            var xmlStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            return (Feed) serializer.Deserialize(xmlStream);
        }
    }
}