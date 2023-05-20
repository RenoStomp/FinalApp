using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO
{
    public class ReviewDTO : BaseEntityDTO
    {
        public DateTime RequestCreatedTime { get; set; } = DateTime.UtcNow;
        public string? ReviewText { get; set; }
        public int Evaluation { get; set; }
    }
}
