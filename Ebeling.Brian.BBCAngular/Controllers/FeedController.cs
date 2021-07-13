using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSSLibrary;
using RSSLibrary.Models;

namespace Ebeling.Brian.BBCAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedController : ControllerBase
    {
        private readonly RSSReader rssReader;
        private readonly ILogger<FeedController> logger;

        public FeedController(RSSReader rssReader, ILogger<FeedController> logger)
        {
            this.rssReader = rssReader;
            this.logger = logger;
        }

        [HttpGet]
        public async IAsyncEnumerable<FeedItem> Get()
        {
            // TODO Automapper (overkill for this task)

            var feed = await rssReader.ReadFeedAsync();

            foreach (var item in feed.Channel.Items)
            {
                yield return new FeedItem()
                {
                    Description = item.Description,
                    Link = item.Link,
                    Title = item.Title
                };
            }
        }
    }
}
