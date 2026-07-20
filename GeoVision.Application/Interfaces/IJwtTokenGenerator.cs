using GeoVision.Core.Entities;

namespace GeoVision.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}