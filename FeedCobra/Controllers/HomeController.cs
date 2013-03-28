using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FeedCobra.Services;

namespace FeedCobra.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
