using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vxnet.DTOs.Enums;

namespace vxnet.Domain.Entity
{
    public class Shop : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }//todo during insert new: maybe getting long and latt from address

        [Required]
        public string City { get; set; }

        [Required]
        public ShopAvailability Available { get; set; }

        [Required]
        public string Country { get; set; }

        public string? FotoList { get; set; }

        public string? Description { get; set; }

        public double? Latitude { get; set; }//todo during insert new: maybe getting long and latt from address
        public double? Longitude { get; set; }//todo during insert new: maybe getting long and latt from address

        public virtual ICollection<ProductPerShop> Products { get; set; }


    }
}
