namespace FinalApp.Domain.Models.Abstractions.BaseUsers
{
    public abstract class AccountHolder : BasePerson
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
