using FinalApp.Domain.Models.Common.BaseRequests;
using FinalApp.Domain.Models.Entities.Requests.EcoBoxInfo;

namespace FinalApp.Domain.Models.Entities.Requests.RequestsInfo
{
    public class Location : BaseLocation
    {
        public Request? Request { get; set; }
        public List<EcoBox>? EcoBoxes { get; set; }
    }
}
