using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Budget.Models
{
    public class Category
    {
        public int ID { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}