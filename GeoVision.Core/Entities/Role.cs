using System;

namespace GeoVision.Core.Entities;

using GeoVision.Core.Common;

public class Role : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<User> Users { get; set; } = new List<User>();
}
