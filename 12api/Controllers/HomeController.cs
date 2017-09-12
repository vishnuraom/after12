using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _12api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Title = "About Page";

            return View();
        }

        public ActionResult Categories()
        {
            ViewBag.Title = "Categories Page";

            return View();
        }

        public ActionResult Places()
        {
            ViewBag.Title = "Places Page";

            return View();
        }



        public ActionResult AddPlaces()
        {
            ViewBag.Title = "Add Places Page";

            return View();
        }

        public ActionResult Reviews()
        {
            ViewBag.Title = "Reviews Page";

            return View();
        }

        public ActionResult AddReviews()
        {
            ViewBag.Title = "AddReviews Page";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login Page";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Title = "Register Page";

            return View();
        }

    }
}
