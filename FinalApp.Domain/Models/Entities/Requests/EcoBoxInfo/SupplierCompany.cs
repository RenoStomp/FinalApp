﻿using FinalApp.Domain.Models.Common.BaseRequests;

namespace FinalApp.Domain.Models.Entities.Requests.EcoBoxInfo
{
    public class SupplierCompany : CompanyContactInfo
    {
        public int MaterialPrice { get; set; }

        public ICollection<EcoBoxTemplate>? EcoBoxTemplates { get; set; }
    }
}
