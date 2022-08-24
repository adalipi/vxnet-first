using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vxnet.Domain.Entity
{
    public class Shop : BaseEntity
    {
        [Key]
        //[ForeignKey("Shop")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public bool Open { get; set; }

        public string? FotoList { get; set; }

        public string? Description { get; set; }

    }
}
