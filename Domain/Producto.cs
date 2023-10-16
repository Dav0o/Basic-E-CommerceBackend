using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class Producto
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int ProductPrice { get; set; }
        public int Quantity { get; set; }


        [JsonIgnore]
        public List<Details>? Details { get; set; }
    }
}
