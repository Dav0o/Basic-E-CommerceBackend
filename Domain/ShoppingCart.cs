using Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ShoppingCart : BaseEntity
    {

        public int TotalAmount { get; set; }
        public int SubTotal { get; set; }

        public int Total { get; set; }

        public List<Cart_Product> Cart_Products { get; set; }

    }
    
}
