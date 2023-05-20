namespace FinalApp.Domain.Models.Common.BaseUsersInfo
{
    public abstract class PersonalContactInfo : AccountHolder
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
