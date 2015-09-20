using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShoping.Model
{
   [Table("BrandMaster")]
   public class BrandModel:BaseEntity
   {
       [Required]
       [MaxLength(50)]
       [Display(Name = "Brand Name")]
       [Index("IX_FirstAndSecond", 1, IsUnique = true)]
       public string Name { get; set; }

       [MaxLength(500)]
       [Display(Name = "Brand Detail")]
       public string Detail { get; set; }

       [MaxLength(500)]
       [Display(Name = "Brand Logo")]
       public string Logo { get; set; }
    }
}
