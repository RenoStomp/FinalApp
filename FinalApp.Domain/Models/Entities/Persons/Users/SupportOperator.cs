using FinalApp.Domain.Models.Common;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Persons.Users
{
    public class SupportOperator : BaseUser
    {
        public override Roles UserType { get; set; }
    }
}
