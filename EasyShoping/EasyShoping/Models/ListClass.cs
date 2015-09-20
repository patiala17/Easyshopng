using EasyShoping.Model;
using EFFilter.EntityFramework.Search;
using EFFilter.Sort;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWorks;

namespace EasyShoping.Models
{
    public class ListClass
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public StaticPagedList<LocationModel> getLocations(int? pageNo)
        {  //create the query
            var query = new SearchQuery<LocationModel>();
            //   query.AddFilter(product => product.UserName =="");

            //this is the same as the following
            query.AddFilter(c => c.IsDelete == false);
            var pageNumber = pageNo ?? 1;
            query.Take = 10;
            query.Skip = pageNumber - 1;
            var result = unitOfWork.LocationRepository.Search(query);

            return new StaticPagedList<LocationModel>(result.Entities, pageNumber, query.Take, result.Count);
        }
        public StaticPagedList<BrandModel> getBrands(int? pageNo)
        {  //create the query
            var query = new SearchQuery<BrandModel>();
            //   query.AddFilter(product => product.UserName =="");

            //this is the same as the following
            query.AddFilter(c => c.IsDelete == false);
            var pageNumber = pageNo ?? 1;
            query.Take = 10;
            query.Skip = pageNumber - 1;
            var result = unitOfWork.BrandRepository.Search(query);

            return new StaticPagedList<BrandModel>(result.Entities, pageNumber, query.Take, result.Count);
        }
        public StaticPagedList<CategoryModel> getCategories(int? pageNo)
        {  //create the query
            var query = new SearchQuery<CategoryModel>();
            //   query.AddFilter(product => product.UserName =="");

            //this is the same as the following
            query.AddFilter(c => c.IsDelete == false);
            var pageNumber = pageNo ?? 1;
            query.Take = 10;
            query.Skip = pageNumber - 1;
            var result = unitOfWork.CategoryRepository.Search(query);

            return new StaticPagedList<CategoryModel>(result.Entities, pageNumber, query.Take, result.Count);
        }
        public StaticPagedList<ProductModel> getProducts(int? pageNo)
        {  //create the query
            var query = new SearchQuery<ProductModel>();
            //   query.AddFilter(product => product.UserName =="");
            
            //this is the same as the following
            query.AddFilter(c => c.IsDelete == false);
            query.AddSortCriteria(new FieldSortCriteria<ProductModel>("LastUpdate", SortDirection.Descending));
            var pageNumber = pageNo ?? 1;
            query.Take = 10;
            query.Skip = pageNumber - 1;
            var result = unitOfWork.ProductRepository.Search(query);

            return new StaticPagedList<ProductModel>(result.Entities, pageNumber, query.Take, result.Count);
        }

    }
}