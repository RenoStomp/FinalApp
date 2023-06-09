﻿using FinalApp.Domain.Models.Common.BaseRequests;

namespace FinalApp.Domain.Models.Entities.Requests.RequestsInfo
{
    public class Review : BaseRequest
    {
        public string? ReviewText { get; set; }
        public int Evaluation { get; set; }

        public Request? Request { get; set; }
    }
}
