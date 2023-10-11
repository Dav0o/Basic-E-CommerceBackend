using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Relations
{
    public class Cart_Product
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

      
    }
}
