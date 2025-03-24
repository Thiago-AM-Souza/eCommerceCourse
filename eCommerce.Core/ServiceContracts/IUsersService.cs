using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts
{
    public interface IUsersService
    {
        Task<AuthenticationResponseDTO?> Login(LoginRequestDTO loginRequestDTO);

        Task<AuthenticationResponseDTO?> Register(RegisterRequestDTO registerRequestDTO);
    }
}
