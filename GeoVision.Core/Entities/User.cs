using System;

using GeoVision.Core.Common;

namespace GeoVision.Core.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    // Foreign Key
    public int RoleId { get; set; }

    // Navigation Property
    public Role Role { get; set; } = null!;

    // Navigation Property
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
