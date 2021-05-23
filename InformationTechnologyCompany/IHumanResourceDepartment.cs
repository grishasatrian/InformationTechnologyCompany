using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public interface IHumanResourceDepartment
    {
        void Hire(Team team, SpecialistType specialistType, QualificationLevel qualificationLevel, string personalId, string firstName, 
            string lastName, string numberPhone, string email, DateTime birthDate);

        void Fire(Team team, Employee employee);
    }
}
