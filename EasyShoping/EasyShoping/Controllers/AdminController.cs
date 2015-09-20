using EasyShoping.Model;
using EasyShoping.Models;
using EFFilter.EntityFramework.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UnitOfWorks;

namespace EasyShoping.Controllers
{
    public class AdminController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Admin/
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid) {
                var query = new SearchQuery<UserModel>();
                //   query.AddFilter(product => product.UserName =="");
                //this is the same as the following

                query.AddFilter(c => c.UserName == model.UserName);
                query.Take = 1;

                var result = unitOfWork.UserRepository.Search(query).Entities.FirstOrDefault();
                if (result != null)
                {
                    if (result.Password == model.Password)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, false);
                        return RedirectToAction("Index", "Location");

                    } ModelState.AddModelError("", "Login data is incorrect!");
                    return View(model);
                }
                ModelState.AddModelError("", "Login data is incorrect!");
                return View(model);
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Admin");
        }
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
