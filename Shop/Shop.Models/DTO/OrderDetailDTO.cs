namespace Shop.Models.DBModel.DTO {

    public class OrderDetailDTO {
        public int OrderDetailId { set; get; }
        public int ProductId { set; get; }
        public int OrderId { set; get; }
        public /*ICollection<ProductDTO>*/ ProductDTO Product { set; get; }
    }
}