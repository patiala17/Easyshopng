using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShoping.Model
{
    [Table("Products")]
    public class ProductModel : BaseEntity
    {



        public Int64? CategoryID { get; set; }
        public Int64? SubCategoryID { get; set; }
        public Int64? SubSubCategoryID { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        /// <summary>
        /// Standard cost of the product.
        /// </summary>
        [DataType(DataType.Currency)]
        public decimal StandardCost { get; set; }

        /// <summary>
        /// Selling price.
        /// </summary>
        [DataType(DataType.Currency)]
        public decimal ListPrice { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Product SKU")]
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        public string ProductCode { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Full Description")]
        public string FullDescription { get; set; }

        //[Key, ForeignKey("LocationID")]
        //public virtual LocationModel Locations { get; set; }
        //public Int64 LocationID { get; set; }

        public String LocationCode { get; set; }

        public Int64 BrandID { get; set; }
        [Key, ForeignKey("BrandID")]
        public virtual BrandModel Brands { get; set; }


    }

    [Table("ProductsImages")]
    public class ProductsImagesModel : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        [Display(Name = "Image Name")]
        public string Name { get; set; }

        public string ImageURL { get; set; }
        public string smallImageURL { get; set; }

        public bool IsMainImage { get; set; }
        public Int64 ProductID { get; set; }

        public string ProductCode { get; set; }
    }
    [Table("ProductsVideos")]
    public class ProductsVideosModel : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        [Display(Name = "Video Name")]
        public string Name { get; set; }

        public string ImageURL { get; set; }
        public string smallImageURL { get; set; }

        public string VideoURL { get; set; }

        public bool IsMainImage { get; set; }
        public Int64 ProductID { get; set; }

        public string ProductCode { get; set; }
    }
}
