using FinalApp.Domain.Models.Common.BaseRequests;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Requests.EcoBoxInfo
{
    public class EcoBoxTemplate : BaseEcoBox
    {
        public Materials MaterialType { get; set; }
        public TrashTypes TrashType { get; set; }
        public string Capacity { get; set; }

        public List <EcoBox>? EcoBox { get; set; }
    }
}
