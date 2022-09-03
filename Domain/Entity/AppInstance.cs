using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vxnet.Domain.Entity
{
    public class AppInstance : BaseEntity
    {
        [Key]
        [Required]
        [ForeignKey("AppInstance")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public int LoginCount { get; set; }
    }
}
