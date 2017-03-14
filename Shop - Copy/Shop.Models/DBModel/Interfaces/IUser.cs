using Shop.Models.DBModel;
using System;
using System.Collections.Generic;

namespace Shop.Models.Interfaces {

    public interface IUser {
        int UserId { set; get; }
        string username { set; get; }
        string password { set; get; }
        string name { set; get; }
        string email { set; get; }
        string surname { set; get; }
        string lastName { set; get; }
        int age { set; get; }
        DateTime regDate { set; get; }
        bool userMode { set; get; }
        UserInfo UserInfo { set; get; }
        ICollection<ReviewProduct> ReviewProducts { get; set; }
        ICollection<Order> Orders { get; set; }
        ICollection<Address> Address { set; get; }
        ICollection<UserType> UserType { set; get; }
    }
}