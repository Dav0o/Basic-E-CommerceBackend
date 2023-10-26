namespace Domain.DTO
{
    //este DTO es pa agregar los products al cart 
    public class ProductAddDTO
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
