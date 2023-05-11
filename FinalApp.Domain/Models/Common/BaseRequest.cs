using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Common
{
    public abstract class BaseRequest : BaseEntity
    {
        public Status OrderStatus { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    }
}
