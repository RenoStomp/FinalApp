﻿using FinalApp.Domain.Models.Common.BaseEntities;

namespace FinalApp.Domain.Models.Common.BaseRequests
{
    public abstract class BaseRequest : BaseEntity
    {
        public DateTime RequestCreatedTime { get; set; } = DateTime.UtcNow;
    }
}
