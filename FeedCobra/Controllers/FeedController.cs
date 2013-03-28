using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeedCobra.Services;

namespace FeedCobra.Controllers
{
    public class FeedController : Controller
    {
        private readonly FeedService service;

        public FeedController(FeedService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize, OutputCache(Duration = 5 * 60, VaryByParam = "*")]
        public ActionResult Feed(int skip = 0, int count = 10)
        {
            var feed = service.GetFeedForUser(User.Identity.Name).Skip(skip).Take(count);

            return View(feed);
        }
    }
}
