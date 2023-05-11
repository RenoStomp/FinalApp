using FinalApp.Domain.Models.Common;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Users
{
    public class SupportOperator : BaseUser
    {
        public override Roles Role { get; set; } = Roles.TechnicalSupportOperator;
    }
}
