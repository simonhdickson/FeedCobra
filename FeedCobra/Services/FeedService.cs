using System;
using System.Collections.Generic;
using System.Linq;
using Argotic.Syndication;
using FeedCobra.Models;

namespace FeedCobra.Services
{
    public class FeedService : IFeedService<RssItem>
    {
        private readonly SubscriptionContext subscriptionContext;

        public FeedService(SubscriptionContext subscriptionContext)
        {
            this.subscriptionContext = subscriptionContext;
        }

        public IEnumerable<RssItem> GetFeedForUser(string username)
        {
            var feed = subscriptionContext.Subscriptions
                            .Where(s => s.Feed.Type == "rss")
                            .Select(s => s.Feed.XmlUrl).ToArray()
                            .Select(f => RssFeed.Create(new Uri(f)))
                            .SelectMany(r => r.Channel.Items)
                            .OrderBy(i => i.PublicationDate);
            return feed;
        }
    }
}