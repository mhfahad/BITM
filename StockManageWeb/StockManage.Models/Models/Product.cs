using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManage.Models.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Not null")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Not null")]
        [StringLength(50, MinimumLength = 3)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Not null")]
        [StringLength(50, MinimumLength = 3)]
        public string Category { get; set; }

        [Required]
        public int ReorderLevel { get; set; }

        [Required(ErrorMessage = "Not null")]
        [StringLength(50, MinimumLength = 3)]
        public string Discription { get; set; }


        [NotMapped]
        public List<Category> categories { get; set; }

        [NotMapped]
        public List<Product> products { get; set; }
    }
}
