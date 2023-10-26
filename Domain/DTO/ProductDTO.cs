namespace Domain.DTO
{
    //este DTO es pa agregar los products a la tabla products
    public class ProductDTO
    {
        public string productId { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }

        public int productQuantity { get; set; }
    }
}
