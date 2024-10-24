using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTOs
{
    public class Capital
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Acronimo { get; set; }
        public string CodigoPostal { get; set; }
        public int PaisID { get; set; }
    }
}
