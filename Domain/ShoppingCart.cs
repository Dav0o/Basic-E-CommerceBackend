using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class ShoppingCart
    {
        [Key]
        public string cartId { get; set; }
        public string customerId { get; set; }

        public List<ProductCart> ProductCarts { get; set; } = new List<ProductCart>();

        public DateTime date { get; set; }

        public double total { get; set; }

        public double subTotal { get; set; }

    }
    
}
