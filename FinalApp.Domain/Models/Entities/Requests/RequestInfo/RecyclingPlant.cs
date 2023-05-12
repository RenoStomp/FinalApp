﻿using FinalApp.Domain.Models.Common.BaseRequests;

namespace FinalApp.Domain.Models.Entities.Requests.RequestInfo
{
    public class RecyclingPlant : CompanyContactInfo
    {
        public int Income { get; set; }

        public List<Request>? Requests { get; set; }
    }
}
