using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TermProject.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }




        
        public ActionResult About()
        {
            return View();
        }


        public ActionResult VotingInformation()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}
