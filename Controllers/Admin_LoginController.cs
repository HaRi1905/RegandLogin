using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegandLogin.Models;

namespace RegandLogin.Controllers
{
    public class Admin_LoginController : Controller
    {
        practice_purposeEntities db1 = new practice_purposeEntities();

        // GET: Admin_Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Admin objcheck)
        {

            if (ModelState.IsValid)
            {
                using (practice_purposeEntities db1 = new practice_purposeEntities())
                {
                    var obj = db1.Admins.Where(a => a.Admin_Name.Equals(objcheck.Admin_Name) && a.Admin_Password.Equals(objcheck.Admin_Password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["Admin_Id"] = obj.Admin_Id.ToString();
                        Session["Admin_Name"] = obj.Admin_Name.ToString();
                        return RedirectToAction("Index", "Admins");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect UserName or Password");

                    }
                }
            }

            return View(objcheck);

        }
    }
}
    