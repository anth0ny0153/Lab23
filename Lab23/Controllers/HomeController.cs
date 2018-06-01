using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab23.Models;

namespace Lab23.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();
            ViewBag.ItemList = ORM.Items.ToList();
            ViewBag.Message = "Items added to DB";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SignUpForm()
        {
            return View();
        }
        public ActionResult AddNewUser(User newUser)
        {
            if (ModelState.IsValid)
            {
                CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();
                ORM.Users.Add(newUser);
                ORM.SaveChanges();
                ViewBag.Message = $"Welcome {newUser.firstname}";
                return RedirectToAction("Confirm");
            }
            else
            {
                ViewBag.Message = "Invalid input";
                return View();
            }
        }
        public ActionResult Confirm()
        {
            ViewBag.Message = "Congratulations!";
            return View();
        }
    }
}