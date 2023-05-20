using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.ApiModels.DTOs.EntitiesDTOs.UsersDTOs
{
    public class TechnicalTeamDTO : UsersDTO
    {
        public  Roles UserType { get; set; } = Roles.TechnicalSpecialist;
        public int? WorkerId { get; set; }

    }
}
