using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Details
    {
        public int Id { get; set; }

        public int ProductoId { get; set; }

        public Producto? Producto { get; set; }

        public int CartId { get; set; }

        public ShoppingCart? ShoppingCart { get; set; }

        public int Quantity { get; set; }




    }
}
