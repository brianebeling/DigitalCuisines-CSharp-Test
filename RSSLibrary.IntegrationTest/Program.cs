using System;

namespace RSSLibrary.IntegrationTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var reader = new RSSReader("https://feeds.bbci.co.uk/news/rss.xml");

            var feed = reader.ReadFeed();

            Console.WriteLine($"Version {feed.Version}");

            foreach (var rssChannelItem in feed.Channel.Items)
                Console.WriteLine($"Title> {rssChannelItem.Title} {Environment.NewLine} {rssChannelItem.Description}");

            Console.ReadKey();
        }
    }
}