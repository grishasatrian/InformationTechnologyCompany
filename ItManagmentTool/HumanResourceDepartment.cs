using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public class HumanResourceDepartment : Department
    {
        Employee director;
        string companyId;
        DepartmentName departmentName;
        Dictionary<string, string> emailDictionary = new Dictionary<string, string>();

        Dictionary<string, Employee> employeesPool = new Dictionary<string, Employee>();
        Dictionary<string, Team> teamPool = new Dictionary<string, Team>();
        Dictionary<string, Department> departmentPool = new Dictionary<string, Department>();
        Dictionary<string, Company> companyPool = new Dictionary<string, Company>();
        
        public HumanResourceDepartment(DepartmentName departmentName, string companyId) : base(departmentName)
        {
            this.companyId = companyId;
        }

        
        public bool HrAuthority 
        {
            get
            { 
                return this.departmentName == DepartmentName.HR;
            }
        }
        
        public DepartmentName DepartmentName { get => departmentName; set => departmentName = value; }

        public void AddTeam(Team team)
        {
            team.DepartmentId = this.UnitId;
            this.AddMember(team, true);
        }
        
        public void RemoveTeam(Team team)
        {
            team.DepartmentId = this.UnitId;
            this.RemoveMember(team, true);
        }

        public void Hire(Team team, SpecialistType specialistType, QualificationLevel qualificationLevel, 
            string personalId, string firstName, string lastName, string numberPhone, string email, DateTime birthDate)
        {
            if (HrAuthority)
            {
                Employee employee = new Employee(specialistType, qualificationLevel, personalId, firstName,
                    lastName, numberPhone, email, birthDate);
                team.AddEmployee(employee);
                //Hire(team, employee);
                if(!emailDictionary.ContainsKey((GetEmailKey(firstName, lastName))))
                {
                    emailDictionary.Add(GetEmailKey(firstName, lastName), employee.Email);
                }
            }
            else
            {
                Console.WriteLine("Contact the HR department for that question");
            }
        }

        public string GetEmail(string firstName, string lastName)
        {
            if (emailDictionary.ContainsKey(GetEmailKey(firstName, lastName)))
            {
                return emailDictionary.GetValueOrDefault(GetEmailKey(firstName, lastName), null);
            }
            return null;
        }

        /*public void Hire(Team team, Employee employee)
        {
            team.AddEmployee(employee);
        }*/

        public void Fire(Team team, Employee employee)
        {
            if (HrAuthority)
            {
                emailDictionary.Remove(GetEmailKey(employee.FirstName, employee.LastName));
                team.RemoveEmployee(employee);
            }
            else
            {
                Console.WriteLine("Contact the HR department for that question");
            }
        }

        string GetEmailKey(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }


    }
}
