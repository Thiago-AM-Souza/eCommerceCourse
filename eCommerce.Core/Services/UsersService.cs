using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    public class UsersService : IUsersService
    {
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        private readonly IUsersRepository _usersRepository;

        public async Task<AuthenticationResponseDTO?> Login(LoginRequestDTO loginRequestDTO)
        {
            ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequestDTO.Email, loginRequestDTO.Password);

            if (user == null)
            {
                return null;
            }

            return new AuthenticationResponseDTO(user.Id, user.Email, user.Name, user.Gender, "token", true);
        }

        public async Task<AuthenticationResponseDTO?> Register(RegisterRequestDTO registerRequestDTO)
        {
            ApplicationUser user = new()
            {
                Name = registerRequestDTO.PersonName,
                Email = registerRequestDTO.Email,
                Password = registerRequestDTO.Password,
                Gender = nameof(registerRequestDTO.Gender),
            };

            ApplicationUser? registeredUser = await _usersRepository.AddUser(user);

            if (registeredUser == null)
            {
                return null;
            }

            return new AuthenticationResponseDTO(registeredUser.Id, registeredUser.Email, registeredUser.Name, registeredUser.Gender, "token", true);
        }
    }
}
