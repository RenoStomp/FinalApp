using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Common.BaseRequests
{
    public abstract class RequestInfo : BaseRequest
    {
        public abstract Status RequestStatus { get; set; }
        public abstract Types RequestType { get; set; }
    }
}
