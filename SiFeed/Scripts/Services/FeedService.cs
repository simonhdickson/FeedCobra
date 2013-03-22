using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Argotic.Syndication;

namespace SiFeed.Services
{
    public class FeedService
    {
        public IEnumerable<RssItem> GetFeedForUser(string username)
        {
            var feed = RssFeed.Create(new Uri("http://www.pwop.com/feed.aspx?show=dotnetrocks&filetype=master"));

            return feed.Channel.Items;
        }
    }
}