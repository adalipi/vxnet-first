
namespace vxnet.Domain.Entity
{
    public class UserManager : BaseEntity
    {
        public string Username { get; set; }
        public string HashedPassword { get; set; }
    }
}
