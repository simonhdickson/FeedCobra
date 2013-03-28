using System;
using System.Linq;
using System.Web.Mvc;
using Argotic.Syndication;
using SiFeed.Services;

namespace SiFeed.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int skip = 0, int count = 10)
        {
            var service = new FeedService();

            var feed = service.GetFeedForUser(User.Identity.Name).Skip(skip).Take(count);

            return View(feed);
        }

    }
}
