namespace FinalApp.Domain.Models.Common
{
    public abstract class PersonalContactInfo : BasePerson
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
