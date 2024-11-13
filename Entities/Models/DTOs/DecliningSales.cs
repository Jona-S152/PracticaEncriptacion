using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTOs
{
    public class DecliningSales
    {
        public int OrderQuarter { get; set; }
        public decimal SalesPerQuarter { get; set; }
    }
}
