
using System.Text.Json.Serialization;

namespace Domain.DTO
{

    //este DTO es pa generar el json como lo quiere el profe
    //en el controlador na mas jalamos este dto y sustituimos
    public class CartDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<ProductAddDTO> Products { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
    }
}