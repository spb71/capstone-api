using CapstoneAPI.Models;
using CapstoneAPI.Models.Dto;

namespace CapstoneAPI.Repo.IRepo
{
	public interface IUserRepository
	{
		bool IsUniqueUser(string username);
		Task<LoginResponseDTO> Login(LoginRequestDTO loginReq);
		Task<User> Register(RegistrationRequestDTO regReqDTO);
	}
}
