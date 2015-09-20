using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShoping.Model
{
    [Table("UserMaster")]
    public class UserModel:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        [Display(Name="User Name")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
    }
}
