using Shop.Models.DBModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.DTO {
    public class UserTypeDTO {
        public int UserTypeId { set; get; }
        public string type { set; get; }
        public string typeDesc { set; get; }
        public int UserId { set; get; }
        public virtual UserDTO User { set; get; }
    }
}
