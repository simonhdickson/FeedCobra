using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Argotic.Syndication;
using FeedCobra.Services;

namespace FeedCobra.Controllers
{
    public class FeedController : Controller
    {
        private readonly IFeedService<RssItem> service;

        public FeedController(IFeedService<RssItem> service)
        {
            this.service = service;
        }

        [Authorize, OutputCache(Duration = 5 * 60, VaryByParam = "*")]
        public ActionResult Index(int skip = 0, int count = 10)
        {
            var feed = service.GetFeedForUser(User.Identity.Name).Skip(skip).Take(count);

            return View(feed);
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }
    }
}
