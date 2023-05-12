using FinalApp.Domain.Models.Common.BaseUsersInfo;
using FinalApp.Domain.Models.Entities.Persons.WorkTeams;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Persons.Users
{
    public class TechnicalTeam : BaseUser
    {
        public override Roles UserType { get; set; } = Roles.TechnicalSpecialist;

        public Request? Request { get; set; }

        public List<Worker> Workers { get; set; }
        public int? WorkerId { get; set; }

    }
}
