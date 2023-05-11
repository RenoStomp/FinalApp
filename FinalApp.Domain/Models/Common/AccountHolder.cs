namespace FinalApp.Domain.Models.Common
{
    public abstract class AccountHolder : PersonalContactInfo
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
