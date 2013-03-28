using System.Collections.Generic;

namespace FeedCobra.Services
{
    public interface IFeedService<out TItem>
    {
        IEnumerable<TItem> GetFeedForUser(string username);
    }
}