namespace DOANCS.Models
{
    public class Size
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductDetail>? ProductDetails { get; set; }


    }
}
