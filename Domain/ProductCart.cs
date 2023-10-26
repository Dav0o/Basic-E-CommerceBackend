using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductCart
    {
        public int Id { get; set; }

        public string ProductoId { get; set; }

        public Producto? Producto { get; set; }

        public string CartId { get; set; }

        [JsonIgnore]
        public ShoppingCart? ShoppingCart { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public int Quantity { get; set; }




    }
}
