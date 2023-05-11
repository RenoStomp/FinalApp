using FinalApp.Domain.Models.Common.BaseRequests;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Requests.RequestInfo
{
    public class Request : Common.BaseRequests.RequestInfo
    {
        public string? Comment { get; set; }
        public int BoxQuantity { get; set; }
        public DateTime CompletedTime { get; set; }



        public override Types RequestType { get; set; } = Types.RequestExecution;
        public override Status RequestStatus { get; set; } = Status.InProgress;
    }
}
