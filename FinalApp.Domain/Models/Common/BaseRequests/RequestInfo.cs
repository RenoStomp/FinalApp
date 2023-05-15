using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Common.BaseRequests
{
    public abstract class RequestInfo : BaseRequest
    {
        public virtual Status RequestStatus { get; set; }
        public virtual Types RequestType { get; set; }
    }
}
