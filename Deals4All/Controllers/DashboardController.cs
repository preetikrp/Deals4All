using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deals4All.Filters;

namespace Deals4All.Controllers
{
    public class DashboardController : Controller
    {
        Customizations customclass = new Customizations();
        // GET: /Dashboard/
        //[MyExceptionHandler]
        //[Authorize(Roles = "Admin")]
        [Authorize]
        public ActionResult MerchantDashboard()
        {
            return View();
        }

        //[MyExceptionHandler]
        //[Authorize(Roles = "SystemUser")]
        [Authorize]
        public ActionResult CustomerDashboard()
        {
            return View();
        }

        [Authorize]
        public ActionResult Index()
        {
            int MerchantID = customclass.MerchantID(User.Identity.GetUserName());
            //if (string.IsNullOrEmpty(Convert.ToString(MerchantID)))
            if (MerchantID == 0)
            {

                return RedirectToAction("CustomerDashboard", "Dashboard");

            }
            else 

            {
                return RedirectToAction("MerchantDashboard", "Dashboard");

            }

            return View();
        }

    }
}