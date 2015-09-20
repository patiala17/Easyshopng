using EasyShoping.Model;
using EasyShoping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWorks;

namespace EasyShoping.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        #region Location
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Location/

        public ActionResult Index(int? pageNo=1)
        {
            ListClass _list = new ListClass();
            ViewBag.List = _list.getLocations(pageNo); 
            return View();
        }

        //
        // GET: /Location/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Location/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Location/Create

        [HttpPost]
        public ActionResult Create(LocationModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.LocationRepository.Insert(model);
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
        // GET: /Location/Edit/5

        public ActionResult Edit(int id)
        {
            return View(unitOfWork.LocationRepository.GetByID(id));
        }

        //
        // POST: /Location/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, LocationModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _data = unitOfWork.LocationRepository.GetByID(model.ID);
                    _data.IsActive = model.IsActive;
                    _data.LocationName = model.LocationName;
                    _data.LocationCode = model.LocationCode;
                    _data.LastUpdate = DateTime.Now;
                    unitOfWork.LocationRepository.Update(_data);
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
        // POST: /Location/Delete/5

        [HttpPost]
        public string Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                unitOfWork.LocationRepository.Delete(id);
                unitOfWork.Save();
                return ActionMessage.Delete;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}
