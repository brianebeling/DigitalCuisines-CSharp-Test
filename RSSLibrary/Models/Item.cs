using System.Xml.Serialization;

namespace RSSLibrary.Models
{
    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "title")] public string Title { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "link")] public string Link { get; set; }

        [XmlElement(ElementName = "guid")] public Guid Guid { get; set; }

        [XmlElement(ElementName = "pubDate")] public string PubDate { get; set; }
    }
}