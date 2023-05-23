using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.ApiModels.DTOs.EntitiesDTOs.UsersDTOs;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO
{
    public class RequestDTO : BaseEntityDTO
    {
        public string? Comment { get; set; }
        public int BoxQuantity { get; set; }
        public DateTime CompletedTime { get; set; }
        public WorkTypes WorkType { get; set; }
        public Types RequestType { get; set; } = Types.RequestExecution;
        public Status RequestStatus { get; set; }

        public int? ClientId { get; set; }
        public RecyclingPlantDTO RecyclingPlant { get; set; }
        public int? PlantId { get; set; }
        public LocationDTO Location { get; set; }
        public int? LocationId { get; set; }
        public SupportOperatorDTO SupportOperator { get; set; }
        public int? OperatorId { get; set; }
        public ReviewDTO Review { get; set; }
        public int? ReviewId { get; set; }
        public TechnicalTeamDTO TechnicalTeam { get; set; }
        public int? TechTeamId { get; set; }
    }
}
