using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using FeedCobra.Models;

namespace FeedCobra.Services
{
    public class OmplService
    {
        public IEnumerable<Feed> GetFeeds(Stream stream)
        {
            var doc = XDocument.Load(stream);
            doc.
        }
    }
}