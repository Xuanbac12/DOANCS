namespace DOANCS.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColorId {  get; set; }
        public int SizeId {  get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        
    }   
}
