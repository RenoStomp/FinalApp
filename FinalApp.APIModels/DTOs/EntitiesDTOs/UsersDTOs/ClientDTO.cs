using FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs;
using FinalApp.Domain.Models.Enums;

namespace FinalApp.ApiModels.DTOs.EntitiesDTOs.UsersDTOs
{
    public class ClientDTO : UsersDTO
    {
        public  Roles UserType { get; set; } = Roles.Client;

    }
}
