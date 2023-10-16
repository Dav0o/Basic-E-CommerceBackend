using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        

        public double SubTotal { get; set; }

        public double Total { get; set; }

        public DateTime ShoppingDate { get; set; }

        
        public List<ProductCart> ProductCarts { get; set; } = new List<ProductCart>();

    }
    
}
