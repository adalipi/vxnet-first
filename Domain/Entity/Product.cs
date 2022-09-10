using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vxnet.Domain.Entity
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string? Barcode { get; set; }

        public string? FotoList { get; set; }

        public string? Description { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        public virtual ICollection<ProductPerShop> Products { get; set; }
    }
}
