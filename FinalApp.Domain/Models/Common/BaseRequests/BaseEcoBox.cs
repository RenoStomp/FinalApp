﻿using FinalApp.Domain.Models.Common.BaseEntities;

namespace FinalApp.Domain.Models.Common.BaseRequests
{
    public abstract class BaseEcoBox : BaseEntity
    {
        public int ProductPrice { get; set; }
    }
}
