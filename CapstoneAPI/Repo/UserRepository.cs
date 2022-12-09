using CapstoneAPI.Data;
using CapstoneAPI.Models;
using CapstoneAPI.Models.Dto;
using CapstoneAPI.Repo.IRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CapstoneAPI.Repo
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _db;
		private readonly string secretKey;

		public UserRepository(ApplicationDbContext db, IConfiguration configuration)
		{
			_db = db;
			secretKey = configuration.GetValue<string>("ApiSettings:Secret");
		}

		public bool IsUniqueUser(string username)
		{
			var user = _db.Users.FirstOrDefault(x => x.Username == username);
			if (user == null)
			{
				return true;
			}
			return false;
		}

		public async Task<LoginResponseDTO> Login(LoginRequestDTO loginReqDTO)
		{
			var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == loginReqDTO.Username
						&& u.Password == loginReqDTO.Password);

			if (user == null)
			{
				return null;
			}

			var tokenHandler = new JwtSecurityTokenHandler();

			var key = Encoding.ASCII.GetBytes(secretKey);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Expires = DateTime.UtcNow.AddDays(7),
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Username.ToString()),
					new Claim(ClaimTypes.Role, user.Role)
				}),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);

			LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
			{
				Token = tokenHandler.WriteToken(token),
				User = user
			};


			return loginResponseDTO;
		}

		public async Task<User> Register(RegistrationRequestDTO regReqDTO)
		{
			User user = new()
			{
				Username = regReqDTO.Username,
				Password = regReqDTO.Password,
				Name = regReqDTO.Name,
				Role = regReqDTO.Role,
			};

			_db.Users.Add(user);

			await _db.SaveChangesAsync();

			user.Password = "";

			return user;
		}
	}
}
