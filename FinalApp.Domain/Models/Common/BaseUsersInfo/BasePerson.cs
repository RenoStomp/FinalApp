namespace FinalApp.Domain.Models.Common.BaseUsersInfo
{
    public abstract class BasePerson : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName
        {
            get
            {
                return $"{Name} {Surname}";
            }
        }


    }
}
