using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Argotic.Syndication;
using SiFeed.Models;

namespace SiFeed.Services
{
    public class FeedService
    {
        public IEnumerable<RssItem> GetFeedForUser(string username)
        {
            using (var db = new UsersContext())
            {
                UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower());
                return feed.Channel.Items;
            }
        }
    }
}