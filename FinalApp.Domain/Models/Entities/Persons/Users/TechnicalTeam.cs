﻿using FinalApp.Domain.Models.Common.BaseUsersInfo;
using FinalApp.Domain.Models.Entities.Requests.RequestInfo;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Persons.Users
{
    public class TechnicalTeam : BaseUser
    {
        public override Roles UserType { get; set; } = Roles.TechnicalSpecialist;

        public Request? Request { get; set; }

    }
}
