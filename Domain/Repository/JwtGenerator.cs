using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using vxnet.DTOs.Models;

namespace vxnet.Domain.Repository
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly JwtDTO _jwtdto;

        public JwtGenerator(IOptions<JwtDTO> options)
        {
            _jwtdto = options.Value;
        }

        public SessionDTO GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtdto.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var exp = DateTime.Now.AddMinutes(_jwtdto.ExpirationMinutes);

            var token = new JwtSecurityToken(_jwtdto.Issuer,
                _jwtdto.Issuer,
                null,
                expires: exp,
                signingCredentials: credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new SessionDTO { Token = tokenString, ExpirationMinutes = _jwtdto.ExpirationMinutes * 60 };
        }
    }
}
