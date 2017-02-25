using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login.Models {
    public class User {
        [Key]
        public string usr { set; get; }
        public string pwd { set; get; }
        public string name { set; get; }
        public string surname { set; get; }
        public string lastname { set; get; }
        public DateTime regDate { set; get; }
        public bool userType { set; get; }
    }
}