using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public enum QualificationLevel
    {
          Undefined,
          Intern,
          EntryLevel,
          Junior,
          Intermediate,
          Senior,
          Director,
          ChiefExecutiveOfficer
    }
    public enum SpecialistType
    {
        Undefined,
        HumanResourceSpecialist,
        FinancilSpecialist,
        SoftwareEngineer,
        QualityAssurenceEngineer,
        ProjectManagementSpecialist,
        MarketingingSpecialist
    }
    public class Employee : Person, IReportable
    {
        string employeeId = CompanyUtil.GetGuid();
        string departmentId;
        string teamId;
        string companyId;
        QualificationLevel qualificationLevel;
        SpecialistType specialistType = SpecialistType.Undefined;
        DateTime hiringDate = DateTime.UtcNow;
        DateTime updateDate;
        DateTime endDate;
        uint salary;

        public Employee(string companyId, string teamId, string departmentId, SpecialistType specialistType,
            QualificationLevel qualificationLevel, uint salary,
            string personalId, string firstName, string lastName, string numberPhone, string email, DateTime birthDate)
            : base(personalId, firstName, lastName, numberPhone, email, birthDate)
        {
            this.companyId = companyId;
            this.departmentId = departmentId;
            this.teamId = teamId;
            this.qualificationLevel = qualificationLevel;
            this.specialistType = specialistType;
            this.salary = salary;
        }

        public Employee(SpecialistType specialistType, QualificationLevel qualificationLevel,
            string personalId, string firstName, string lastName, string numberPhone, string email, DateTime birthDate)
            : base(personalId,  firstName,  lastName,  numberPhone,  email,  birthDate)
        {
            this.qualificationLevel = qualificationLevel;
            this.specialistType = specialistType;
        }

        public string EmployeeId { get => employeeId; set => employeeId = value; }
        public string DepartmentId { get => departmentId; set => departmentId = value; }
        public string TeamId { get => teamId; set => teamId = value; }
        public string CompanyId { get => companyId; set => companyId = value; }
        public QualificationLevel QualificationLevel { get => qualificationLevel; set => qualificationLevel = value; }
        public SpecialistType SpecialistType { get => specialistType; set => specialistType = value; }
        public DateTime HiringDate { get => hiringDate; }
        public DateTime UpdateDate { get => updateDate; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public uint Salary { get => salary; set => salary = value; }

        /*override
        public string ToString()
        {
            string employeeToString = this.FirstName + " " + this.LastName + " ";
            employeeToString += this.PersonalId + " " + this.qualificationLevel.ToString() + " ";
            employeeToString += this.specialistType.ToString() + " " + this.BirthDate;

            return employeeToString;
        }*/

        // Methods
        override
        public string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("first name = {0}, last name = {1}, phone number = {2}," +
                "email = {3}, birthdate = {4}, personal id = {5}, qualification = {6} {7}",
                this.FirstName, this.LastName, this.NumberPhone, this.Email, this.BirthDate, 
                this.PersonalId, this.qualificationLevel, this.specialistType);
            return stringBuilder.ToString();
        }

        public void GenerateReport()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
