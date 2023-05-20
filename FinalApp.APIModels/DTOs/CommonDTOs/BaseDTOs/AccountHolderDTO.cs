namespace FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs
{
    public abstract class AccountHolderDTO : BaseEntityDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
