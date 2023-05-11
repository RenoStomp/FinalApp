using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Common.BaseUsersInfo
{
    public abstract class BaseUser : AccountHolder
    {
        public abstract Roles UserType { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

    }
}
