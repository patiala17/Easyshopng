using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyShoping.Models
{
    public class ProductAPIModel
    {
        public Int64 ID { get; set; }
        public Int64 CategoryID { get; set; }
        public string ProductName { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string ProductCode { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public String LocationCode { get; set; }
        public Int64 BrandID { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<ProductImages> ProductImages { get; set; }

    }
    public class ProductImages
    {
        public Int64 ID { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string smallImageURL { get; set; }
        public bool IsMainImage { get; set; }
    }

}