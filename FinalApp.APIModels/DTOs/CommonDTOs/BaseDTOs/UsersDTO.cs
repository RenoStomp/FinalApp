namespace FinalApp.ApiModels.DTOs.CommonDTOs.BaseDTOs
{
    public class UsersDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
     //   public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
