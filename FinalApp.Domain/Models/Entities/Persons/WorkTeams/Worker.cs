﻿using FinalApp.Domain.Models.Common.BaseUsersInfo;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Persons.WorkTeams
{
    public class Worker : PersonalContactInfo
    {
        public string Salary { get; set; }
        public DateTime HireTime { get; set; } = DateTime.UtcNow;
        public Roles Position { get; set; } = Roles.TechnicalWorker;

        public ICollection<TechnicalTeamWorker> TechnicalTeams { get; set; }
        public int? TeamId { get; set; }
    }
}
