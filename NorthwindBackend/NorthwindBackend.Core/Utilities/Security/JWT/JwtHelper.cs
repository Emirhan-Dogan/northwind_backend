using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public JwtHelper(IConfiguration configuration)
        { 
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Directory.GetCurrentDirectory());
            configurationManager.AddJsonFile("appsettings.json");
            _tokenOptions = new TokenOptions();
            _tokenOptions.Audience = configurationManager.GetConnectionString("Audience");
            _tokenOptions.Issuer = configurationManager.GetConnectionString("Issuer");
            _tokenOptions.AccessTokenExpiration = Convert.ToInt32(configurationManager.GetConnectionString("AccessTokenExpiration"));
            _tokenOptions.SecurityKey = configurationManager.GetConnectionString("SecurityKey");

            //_tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        private TokenOptions _tokenOptions;
        DateTime _accessTokenExpirations;

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            this._accessTokenExpirations = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityToken = new JwtSecurityTokenHandler();
            var token = jwtSecurityToken.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpirations,
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, 
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpirations,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
                );

            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.addNameIdentifier(user.Id.ToString());
            claims.addEmail(user.Email);
            claims.addName($"{user.FirstName} {user.LastName}");
            claims.addRoles(operationClaims.Select(O => O.Name).ToArray());
            return claims;
        }
    }
}
