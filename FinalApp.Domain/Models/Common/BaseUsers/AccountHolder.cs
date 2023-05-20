namespace FinalApp.Domain.Models.Common.BaseUsersInfo
{
    public abstract class AccountHolder : BasePerson
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
