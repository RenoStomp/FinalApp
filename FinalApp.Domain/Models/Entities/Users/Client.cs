using FinalApp.Domain.Models.Common;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Users
{
    public class Client : BaseUser
    {
        private Roles _roles = Roles.Client;
        public override Roles Role
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
            }
        }
    }
}
