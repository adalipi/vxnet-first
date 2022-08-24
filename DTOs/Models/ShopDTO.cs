using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vxnet.DTOs.Models
{
    public class ShopDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public bool Open { get; set; }
        public string Country { get; set; }
    }
}
