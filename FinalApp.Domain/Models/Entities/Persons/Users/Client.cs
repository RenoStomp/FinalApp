﻿using FinalApp.Domain.Models.Common;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Persons.Users
{
    public class Client : BaseUser
    {
        public override Roles UserType { get; set; } = Roles.Client;

    }
}