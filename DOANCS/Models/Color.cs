namespace DOANCS.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDetail>? ProductDetails { get; set; }
    }
}
