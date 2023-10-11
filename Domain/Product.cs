using Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product : BaseEntity
    {

        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        public List<Cart_Product> Cart_Products { get; set;}
     
    }
}
