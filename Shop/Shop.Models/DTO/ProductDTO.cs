using System;

namespace Shop.Models.DBModel.DTO {

    public class ProductDTO {
        public int ProductId { set; get; }
        public string productName { set; get; }
        public string productDesc { set; get; }
        public double productPrice { set; get; }
        public DateTime productModifyDate { set; get; }
        public bool productStatus { set; get; }
        public int productStock { set; get; }
    }
}