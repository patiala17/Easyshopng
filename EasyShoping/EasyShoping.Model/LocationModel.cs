using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShoping.Model
{
   [Table("LocationMaster")]
   public class LocationModel:BaseEntity
    {
       [Required]
       [MaxLength(50)]
       [Display(Name = "Location name")]
       public string LocationName { get; set; }

       [Index("IX_FirstAndSecond", 1, IsUnique = true)]
       [Required]
       [MaxLength(50)]
       [Display(Name = "Location code")]
       public string LocationCode { get; set; }

     
    }
}
