using FinalApp.Domain.Models.Common.BaseRequests;

namespace FinalApp.Domain.Models.Entities.Requests.RequestInfo
{
    public class Location : BaseLocation
    {
        public Request? Request { get; set; }
    }
}
