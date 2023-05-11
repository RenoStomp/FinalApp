﻿namespace FinalApp.Domain.Models.Common
{
    public abstract class Person : BaseEntity
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

        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
