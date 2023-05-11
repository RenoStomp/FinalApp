using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Common
{
    public abstract class BaseRequest : BaseEntity
    {
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public abstract Status RequestStatus { get; set; }
        public abstract Types RequestType { get; set; }
    }
}
