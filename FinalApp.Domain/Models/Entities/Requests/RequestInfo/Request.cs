using FinalApp.Domain.Models.Common;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Requests.RequestInfo
{
    public class Request : BaseRequest
    {
        public string Comment { get; set; }
        public string BoxQuantity { get; set; }
        public DateTime CompletedTime { get; set; }



        public override Types RequestType { get; set; } = Types.RequestExecution;
        public override Status RequestStatus { get; set; } = Status.InProgress;
    }
}
