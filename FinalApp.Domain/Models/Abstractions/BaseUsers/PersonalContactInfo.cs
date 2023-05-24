namespace FinalApp.Domain.Models.Abstractions.BaseUsers
{
    public abstract class PersonalContactInfo : AccountHolder
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
