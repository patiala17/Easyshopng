using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShoping.Model
{
    [Table("CategoryMaster")]
    public class CategoryModel:BaseEntity
    {
      
        [Required]
        [MaxLength(50)]
        [Display(Name = "Category Name")]
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        public string Name { get; set; }

        [MaxLength(500)]
        [Display(Name = "Category Detail")]
        public string Detail { get; set; }

        [MaxLength(500)]
        [Display(Name = "Category Logo")]
        public string Logo { get; set; }
        public Int64 PerentCategoryID { get; set; }
    }
}
