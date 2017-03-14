﻿using Shop.Models.Interfaces;

namespace Shop.Models.DBModel {

    public class ModifyUserModel : IModifyUserModel {
        public string curPassword { set; get; }
        public string newPassword { set; get; }
        public string username { set; get; }
    }
}