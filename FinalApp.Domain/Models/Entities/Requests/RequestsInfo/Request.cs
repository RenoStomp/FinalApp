﻿using FinalApp.Domain.Models.Common.BaseRequests;
using FinalApp.Domain.Models.Entities.Persons.Users;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Entities.Requests.RequestsInfo
{
    public class Request : RequestInfo
    {
        public string? Comment { get; set; }
        public int BoxQuantity { get; set; }
        public DateTime CompletedTime { get; set; }


        public override Types RequestType { get; set; } = Types.RequestExecution;
        public override Status RequestStatus { get; set; } = Status.InProgress;


        public Client Client { get; set; }
        public int? ClientId { get; set; }
        public RecyclingPlant RecyclingPlant { get; set; }
        public int? PlantId { get; set;}
        public Location Location { get; set; }
        public int? LocationId { get; set; }
        public SupportOperator SupportOperator { get; set; }
        public int? OperatorId { get; set; }
        public Review Review { get; set; }
        public int? ReviewId { get; set; }
        public TechnicalTeam TechnicalTeam { get; set; }
        public int? TeamId { get; set; }
       

    }
}
