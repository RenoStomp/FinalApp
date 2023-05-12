namespace FinalApp.Domain.Models.Common.BaseUsersInfo
{
    public abstract class AccountHolder : PersonalContactInfo
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
