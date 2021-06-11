﻿using System.Xml;
using System.Xml.Serialization;
using RSSLibrary.Models;

namespace RSSLibrary
{
    public class RSSReader
    {
        private readonly string endpoint;

        public RSSReader(string endpoint)
        {
            this.endpoint = endpoint;
        }

        public Rss ReadFeed()
        {
            var xmlTextReader = new XmlTextReader(endpoint);
            var serializer = new XmlSerializer(typeof(Rss));
            return (Rss) serializer.Deserialize(xmlTextReader);
        }
    }
}