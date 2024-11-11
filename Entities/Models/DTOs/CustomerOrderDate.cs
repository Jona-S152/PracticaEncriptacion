using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTOs
{
    public class CustomerOrderDate
    {
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
