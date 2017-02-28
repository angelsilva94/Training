using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class OrderUserModel {
        [Key]
        [Required]
        public string orderId { set; get; }
        [Key]
        [Required]
        public string username { set; get; }
    }
}