namespace vxnet.DTOs.Models
{
    public class JwtDTO
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
