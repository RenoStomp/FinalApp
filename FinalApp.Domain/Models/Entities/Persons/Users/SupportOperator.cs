﻿using FinalApp.Domain.Models.Common.BaseUsersInfo;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Persons.Users
{
    public class SupportOperator : BaseUser
    {
        public override Roles UserType { get; set; } = Roles.TechnicalSupportOperator;

        public ICollection<Request>?  Requests { get; set; }
    }
}
