using FinalApp.Domain.Models.Common.BaseRequests;

namespace FinalApp.Domain.Models.Entities.Requests.RequestsInfo
{
    public class RecyclingPlant : CompanyContactInfo
    {
        public int Income { get; set; }

        public ICollection<Request>? Requests { get; set; }
    }
}
