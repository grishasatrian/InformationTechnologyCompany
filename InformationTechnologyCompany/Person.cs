using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public class Person
    {
        string personalId;
        DateTime birthDate;
        DateTime deceasedDate;

        string email;
        string numberPhone;
        string firstName;
        string lastName;
        public Person(string personalId, string firstName, string lastName, string numberPhone, string email, DateTime birthDate)
        {
            this.personalId = personalId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.email = email;
            this.numberPhone = numberPhone;
        }
        
        public string PersonalId { get => personalId; }
        public DateTime BirthDate { get => birthDate; }
        public DateTime DeceasedDate { get => deceasedDate; set => deceasedDate = value; }
        public string FirstName { get => firstName; }
        public string LastName { get => lastName; }
        public string Email { get => email; set => email = value; }
        public string NumberPhone { get => numberPhone; set => numberPhone = value; }
    }
}
