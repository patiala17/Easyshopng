using EasyShoping.Model;
using EasyShoping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnitOfWorks;

namespace EasyShoping.Controllers
{
    public class ItemsController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public IEnumerable<ProductAPIModel> Get(string locationCode)
        {
            List<ProductAPIModel> _ProductAPIModel = new List<ProductAPIModel>();
            List<ProductModel> _data = unitOfWork.ProductRepository.FindAllBy(c => c.LocationCode == locationCode && c.IsActive == true && c.IsDelete == false).ToList();

            foreach (var item in _data)
            {
                _ProductAPIModel.Add(new ProductAPIModel
                {
                    BrandID = item.BrandID,
                    CategoryID = Convert.ToInt64( item.CategoryID),
                    FullDescription = item.FullDescription,
                    ID = item.ID,
                    IsActive = item.IsActive,
                    LastUpdate = item.LastUpdate,
                    ListPrice = item.ListPrice,
                    LocationCode = item.LocationCode,
                    ProductCode = item.ProductCode,
                    ProductImages = getImages(item.ProductCode)
                });

            }
            return _ProductAPIModel;
        }

        private List<ProductImages> getImages(string ProductCode)
        {
            var _data = unitOfWork.ProductsImagesRepository.FindAllBy(c => c.ProductCode == ProductCode);
            List<ProductImages> _list = new List<ProductImages>();
            foreach (var item in _data)
            {
                _list.Add(new ProductImages
                {
                    ID = item.ID,
                    ImageURL = item.ImageURL,
                    IsMainImage = item.IsMainImage,
                    Name = item.Name,
                    smallImageURL = item.smallImageURL
                });
            }
            return _list;
        }
    }
}
