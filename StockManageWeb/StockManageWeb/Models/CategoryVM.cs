using StockManage.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManageWeb.Models
{
    public class CategoryVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public List<Category> categories { get; set; }
    }
}