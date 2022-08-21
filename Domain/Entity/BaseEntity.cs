using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public abstract class BaseEntity
    {

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime ModificationDate { get; set; }

    }
}
