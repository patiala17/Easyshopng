using EasyShoping.Model;
using EasyShoping.Models;
using EFFilter.EntityFramework.Search;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWorks;
namespace EasyShoping.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //
        // GET: /User/
        private UnitOfWork unitOfWork = new UnitOfWork();
      //  [OutputCache(Duration=60,VaryByParam="none",Location=System.Web.UI.OutputCacheLocation.Client)]

        public ActionResult Index(int? pageNo)
        {
            var query = new SearchQuery<UserModel>();
            //   query.AddFilter(product => product.UserName =="");

            //this is the same as the following
            query.AddFilter(c => c.IsDelete == false);
            var pageNumber = pageNo ?? 1;
            query.Take = 10;
            query.Skip = pageNumber - 1;
            var result = unitOfWork.UserRepository.Search(query);


            ViewBag.List = new StaticPagedList<UserModel>(result.Entities, pageNumber, query.Take, result.Count); ; 
            return View();
        }

       

        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.UserRepository.Insert(model);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int? id=0)
        {

            return View(unitOfWork.UserRepository.GetByID(id));
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, UserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _data = unitOfWork.UserRepository.GetByID(model.ID);
                    _data.IsActive = model.IsActive;
                    _data.UserName = model.UserName;
                    _data.Password = model.Password;
                    _data.LastUpdate = DateTime.Now;
                    unitOfWork.UserRepository.Update(_data);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public string Delete(int id)
        {
            try
            {
                if (id == 1)
                {
                    return ActionMessage.AdminAccount;
                }
                unitOfWork.UserRepository.Delete(id);
                unitOfWork.Save();
                return ActionMessage.Delete;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
