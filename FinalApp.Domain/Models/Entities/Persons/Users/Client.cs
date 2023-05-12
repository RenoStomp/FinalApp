using FinalApp.Domain.Models.Common.BaseUsersInfo;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Persons.Users
{
    public class Client : BaseUser
    {
        public override Roles UserType { get; set; } = Roles.Client;

        public List<Request>? Rrequests { get; set; }
    }
}
