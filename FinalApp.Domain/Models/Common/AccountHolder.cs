namespace FinalApp.Domain.Models.Common
{
    public abstract class AccountHolder : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
