using EasyShoping.Model;
using EasyShoping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWorks;

namespace EasyShoping.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index(int? pageNo = 1)
        {
            ListClass _list = new ListClass();
            ViewBag.List = _list.getProducts(pageNo);
            return View();
        }
        public ActionResult Create(string Pid)
        {
            var _brands=unitOfWork.BrandRepository.FindAllBy(c => c.IsActive == true && c.IsDelete == false).Select(x => new { x.ID, x.Name });
            ViewBag.Brands = new SelectList(_brands, "ID", "Name");
            var _locations = unitOfWork.LocationRepository.FindAllBy(c => c.IsActive == true && c.IsDelete == false).Select(x => new { x.LocationCode, x.LocationName });
             List<SelectListItem> items = new SelectList(_locations, "LocationCode", "LocationName").ToList();
             items.Insert(0, (new SelectListItem { Text = "ALL", Value = "ALL" }));
             ViewBag.Locations = items;

             var _Categorys = unitOfWork.CategoryRepository.FindAllBy(c => c.IsActive == true && c.IsDelete == false).Select(x => new { x.ID, x.Name });
             ViewBag.Categorys = new SelectList(_Categorys, "ID", "Name");


             ViewBag.Images = unitOfWork.ProductsImagesRepository.FindAllBy(c => c.ProductCode == Pid);
             ViewBag.Videos = unitOfWork.ProductsVideosRepository.FindAllBy(c => c.ProductCode == Pid);
             var _model = unitOfWork.ProductRepository.FindAllBy(c => c.ProductCode == Pid).FirstOrDefault();
         
         return View(_model);
        }
        [HttpPost]
        public ActionResult Create(ProductModel model)
        {

            var _brands = unitOfWork.BrandRepository.FindAllBy(c => c.IsActive == true && c.IsDelete == false).Select(x => new { x.ID, x.Name });
            ViewBag.Brands = new SelectList(_brands, "ID", "Name");
            var _locations = unitOfWork.LocationRepository.FindAllBy(c => c.IsActive == true && c.IsDelete == false).Select(x => new { x.LocationCode, x.LocationName });
            List<SelectListItem> items = new SelectList(_locations, "LocationCode", "LocationName").ToList();
            items.Insert(0, (new SelectListItem { Text = "All", Value = "0" }));
            ViewBag.Locations = items;
            var _Categorys = unitOfWork.CategoryRepository.FindAllBy(c => c.IsActive == true && c.IsDelete == false).Select(x => new { x.ID, x.Name });
            ViewBag.Categorys = new SelectList(_Categorys, "ID", "Name");

            ViewBag.Images = unitOfWork.ProductsImagesRepository.FindAllBy(c => c.ProductCode == model.ProductCode);
            ViewBag.Videos = unitOfWork.ProductsVideosRepository.FindAllBy(c => c.ProductCode == model.ProductCode);
            try
            {
                if (ModelState.IsValid)
                {
                    var _updatedata = unitOfWork.ProductRepository.FindAllBy(c => c.ProductCode == model.ProductCode).FirstOrDefault();
                    if (_updatedata ==null)
                    {
                        unitOfWork.ProductRepository.Insert(model);
                        unitOfWork.Save();
                    }
                    else
                    {
                       
                        _updatedata.IsActive = model.IsActive;
                        _updatedata.IsDelete = false;
                        _updatedata.ListPrice = model.ListPrice;
                        _updatedata.LocationCode = model.LocationCode;
                        _updatedata.ProductCode = model.ProductCode;
                        _updatedata.ProductName = model.ProductName;
                        _updatedata.ShortDescription = model.ShortDescription;
                        _updatedata.CategoryID = model.CategoryID;
                        _updatedata.StandardCost = model.StandardCost;
                        _updatedata.LastUpdate = DateTime.Now;
                        unitOfWork.ProductRepository.Update(_updatedata);
                        unitOfWork.Save();
                    }
                    return RedirectToAction("Index");
                }


                return View(model);
               
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                return View(model);
            }
        }

        #region Image upload
        public JsonResult Upload(FormCollection forms)
        {
            try
            {
                string ProductCode = forms.Get("ProductCode");
                var file = Request.Files["Filedata"];
                string savePath = Server.MapPath(@"~\Content\ProductImages\" + file.FileName);
                file.SaveAs(savePath);
                ProductsImagesModel model = new ProductsImagesModel();
                model.ImageURL = model.smallImageURL = file.FileName;
                model.IsMainImage = false;
                model.ProductCode = ProductCode;
                model.Name = file.FileName.Substring(0, file.FileName.LastIndexOf('.')); ;
                unitOfWork.ProductsImagesRepository.Insert(model);
                unitOfWork.Save();
                model.ImageURL = Url.Content(@"~\Content\ProductImages\" + file.FileName);
                return Json(model, JsonRequestBehavior.AllowGet);

            }
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Trace.TraceInformation("Property: {0} Error: {1}",
            //                                    validationError.PropertyName,
            //                                    validationError.ErrorMessage);
            //        }
            //    }
            //    return null;
            //}
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public Int32 DeleteImage(Int64 Id)
        {
            Int32 _result = 0;
            try
            {
                var model = unitOfWork.ProductsImagesRepository.GetByID(Id);
                unitOfWork.ProductsImagesRepository.Delete(Id);
                unitOfWork.Save();
                _result = 1;
                System.IO.File.Delete(Server.MapPath(@"~\Content\ProductImages\" + model.ImageURL));
            }
            catch (Exception)
            {

                if (_result != 1)
                {
                    _result = 0;
                }
            }
            return _result;

        }
        [HttpPost]
        public void UpdateImages(ProductsImagesModel model)
        {
            if (ModelState.IsValid)
            {
                var _data = unitOfWork.ProductsImagesRepository.GetByID(model.ID);
                //_data.IsActive = model.IsActive;
                _data.Name = model.Name;
                unitOfWork.ProductsImagesRepository.Update(_data);
                unitOfWork.Save();
            }
        }
        public JsonResult getImages(String sku)
        {
            try
            {

                return Json(unitOfWork.ProductsImagesRepository.FindAllBy(c => c.ProductCode == sku).ToList(), JsonRequestBehavior.AllowGet);

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                return null;
            }
        }
        #endregion

        #region Video upload
        [HttpPost]
        public JsonResult UploadVideo(FormCollection forms)
        {
            try
            {
                string ProductCode = forms.Get("ProductCode");
                var file = Request.Files["Filedata"];
                string savePath = Server.MapPath(@"~\Content\ProductVidoes\" + file.FileName);
                file.SaveAs(savePath);



                //  video = Server.MapPath(savePath);
                string _fileName = file.FileName.Substring(0, file.FileName.LastIndexOf('.')) + ".jpg";
                string thumb = Server.MapPath(@"~\Content\ProductVidoesImages\" + _fileName);
                var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                ffMpeg.GetVideoThumbnail(savePath, thumb);

                ProductsVideosModel model = new ProductsVideosModel();
                model.VideoURL = file.FileName;
                model.ImageURL = _fileName;
                model.IsMainImage = false;
                model.ProductCode = ProductCode;
                model.Name = file.FileName.Substring(0, file.FileName.LastIndexOf('.'));
                unitOfWork.ProductsVideosRepository.Insert(model);
                unitOfWork.Save();
                model.VideoURL = Url.Content(@"~\Content\ProductVidoes\" + file.FileName);
                return Json(model, JsonRequestBehavior.AllowGet);

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                return null;
            }
        }

        [HttpPost]
        public Int32 DeleteVideo(Int64 Id)
        {
            Int32 _result = 0;
            try
            {
                var model = unitOfWork.ProductsVideosRepository.GetByID(Id);
                unitOfWork.ProductsVideosRepository.Delete(Id);
                unitOfWork.Save();
                _result = 1;
                System.IO.File.Delete(Server.MapPath(@"~\Content\ProductVidoesImages\" + model.ImageURL));
                System.IO.File.Delete(Server.MapPath(@"~\Content\ProductVidoes\" + model.VideoURL));
            }
            catch (Exception)
            {

                if (_result != 1)
                {
                    _result = 0;
                }
            }
            return _result;

        }
        [HttpPost]
        public void UpdateVideo(ProductsImagesModel model)
        {
            if (ModelState.IsValid)
            {
                var _data = unitOfWork.ProductsVideosRepository.GetByID(model.ID);
                //_data.IsActive = model.IsActive;
                _data.Name = model.Name;
                unitOfWork.ProductsVideosRepository.Update(_data);
                unitOfWork.Save();
            }
        }
        public JsonResult getVideos(String sku)
        {
            try
            {

                return Json(unitOfWork.ProductsVideosRepository.FindAllBy(c => c.ProductCode == sku).ToList(), JsonRequestBehavior.AllowGet);

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                return null;
            }
        }
        #endregion 

    }
}
