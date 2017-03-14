using Shop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.DBModel {
    public class UserType : IUserType {
        
        public int UserTypeId { set; get; }
        [Required]
        public string type { set; get; }
        [Required]
        public string typeDesc { set; get; }
        public int UserId { set; get; }

        public virtual User User { set; get; }

    }
}
