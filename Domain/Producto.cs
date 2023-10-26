using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class Producto
    {
        [Key]
        public string productId { get; set; }
        public string productName { get; set; }

        public double productPrice { get; set; }

        public int? quantity { get; set; }


        [JsonIgnore]
        public List<ProductCart>? ProductsCart { get; set; }
    }
}
