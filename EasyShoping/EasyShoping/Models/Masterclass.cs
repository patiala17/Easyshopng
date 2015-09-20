using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyShoping.Models
{
    public static class ActionMessage
    {
        public static string Delete = "record deleted successfully";
        public static string Saved = "record saved successfully";
        public static string AdminAccount = "you cannot delete a super administrator";
    }
}