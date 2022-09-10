using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vxnet.Domain.Entity
{
    public abstract class BaseEntity
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime ModificationDate { get; set; }

    }
}
