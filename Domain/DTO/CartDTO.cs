
using System.Text.Json.Serialization;

namespace Domain.DTO
{

    //este DTO es pa generar el json como lo quiere el profe
    //en el controlador na mas jalamos este dto y sustituimos
    public class CartDTO
    {
        public string cartId { get; set; }
        public string customerId { get; set; }
        public List<ProductDTO> products { get; set; }
        public DateTime date { get; set; }
        public double total { get; set; }
        public double subtotal { get; set; }
    }
}