﻿using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Common
{
    public abstract class BaseUser : AccountHolder
    {
        public abstract Roles Role { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

    }
}
