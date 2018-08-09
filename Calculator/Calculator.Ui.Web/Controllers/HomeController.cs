using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calculator.Ui.Web.Models;

namespace Calculator.Ui.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }

    }
}