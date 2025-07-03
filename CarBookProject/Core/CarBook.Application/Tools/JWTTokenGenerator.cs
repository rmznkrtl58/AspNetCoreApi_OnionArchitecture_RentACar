using CarBook.Application.DTOs;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Tools
{ 
	public class JWTTokenGenerator
	{
		//Token Üretici
		public static TokenResponseDTO GenerateToken(GetCheckAppUserQueryResult result)
		{
			//list türünde Kullanıcıya ait bilgileri tutacaz
			var claims = new List<Claim>();
			if (!string.IsNullOrWhiteSpace(result.Role))
				claims.Add(new Claim(ClaimTypes.Role, result.Role));
			claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));


			if (!string.IsNullOrWhiteSpace(result.Username))
				claims.Add(new Claim("Username", result.Username));
			//microsoft.Identity.models.tokens paketi
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTTokenDefaults.Key));

			var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var expireDate = DateTime.UtcNow.AddDays(JWTTokenDefaults.Expire);

			JwtSecurityToken token = new JwtSecurityToken(issuer: JWTTokenDefaults.ValidIssuer, audience: JWTTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate,signingCredentials: signInCredentials);

			JwtSecurityTokenHandler sHandler=new JwtSecurityTokenHandler();
			return new TokenResponseDTO(sHandler.WriteToken(token), expireDate);

			
		}
	}
}
