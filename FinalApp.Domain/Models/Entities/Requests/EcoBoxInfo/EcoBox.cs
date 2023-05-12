using FinalApp.Domain.Models.Common.BaseRequests;
using FinalApp.Domain.Models.Entities.Requests.RequestInfo;

namespace FinalApp.Domain.Models.Entities.Requests.EcoBoxInfo
{
    public class EcoBox : BaseEcoBox
    {
        public int WearDegree { get; set; }

        public Location Location { get; set; }
        public int? LocationId { get; set; }

    }
}
