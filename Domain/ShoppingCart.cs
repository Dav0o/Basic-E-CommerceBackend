using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class ShoppingCart : BaseEntity
    {

        public string? UserId { get; set; }

        public List<Producto>? Cart_Products { get; set; }

        public double SubTotal { get; set; }

        public double Total { get; set; }

        public DateTime ShoppingDate { get; set; } = DateTime.Now;

        //relations
        [JsonIgnore]
        public List<Details>? Details { get; set; }

    }
    
}
