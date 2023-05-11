using FinalApp.Domain.Models.Common.BaseUsersInfo;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Persons.Users
{
    public class TechSpecialist : BaseUser
    {
        public override Roles UserType { get; set; } = Roles.TechnicalSpecialist;
    }
}
