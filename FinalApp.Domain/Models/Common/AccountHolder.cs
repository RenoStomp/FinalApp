namespace FinalApp.Domain.Models.Common
{
    public abstract class AccountHolder : Person
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
