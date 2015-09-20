using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShoping.Model
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }
        public bool IsActive { get; set; }
        private DateTime lastUpdate = DateTime.UtcNow;
        public DateTime LastUpdate { get { return lastUpdate; } set { lastUpdate = value; } }
        public DateTime AddedDate { get { return lastUpdate; } set { lastUpdate = value; } }

        public Int64 UpdateBy { get; set; }

        private bool isDelete = false;
        public bool IsDelete { get { return isDelete; } set { isDelete = value; } }
    }
}
