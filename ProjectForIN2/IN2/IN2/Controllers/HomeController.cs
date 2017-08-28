using IN2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace IN2.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            //Repository = (IRepository)GlobalConfiguration
            //   .Configuration
            //   .DependencyResolver
            //   .GetService(typeof(IRepository));
            Repository = new StudentRepository();
        }
        IRepository Repository;
        // GET: Home
        public ActionResult Index()
        {
            return View(Repository.ListOfStudents);
        }
    }
}