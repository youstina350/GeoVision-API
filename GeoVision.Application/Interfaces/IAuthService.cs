using GeoVision.Application.DTOs.Auth;

namespace GeoVision.Application.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterRequest request);

    Task<AuthResponse> LoginAsync(LoginRequest request);
}