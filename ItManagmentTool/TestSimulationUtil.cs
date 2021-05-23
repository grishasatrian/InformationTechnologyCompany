using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public class TestSimulationUtil
    {
        public static Employee GenerateFutureEmployee()
        {
            var rand = new Random();
            var qualificationLevelCount = Enum.GetNames(typeof(QualificationLevel)).Length;
            QualificationLevel qualificationLevel = (QualificationLevel)rand.Next(1, qualificationLevelCount + 1);
            var specialistTypeCount = Enum.GetNames(typeof(SpecialistType)).Length;
            SpecialistType specialistType = (SpecialistType)rand.Next(1, specialistTypeCount + 1);

            string firstName = TestUtil.GetFirstName();
            string lastName = TestUtil.GetRandomLastName(Ending.Arm, 4);
            DateTime birthDate = TestUtil.GetDateOfBirth(18, 70);
            string personalId = TestUtil.GetGuid();
            string numberPhone = TestUtil.GetRandomPhoneNumber(CountryCode.Armenia, PhoneNumberLength.Armenia);
            string email = TestUtil.GetRandomEmail(10);
            Employee employee = new Employee(specialistType, qualificationLevel, personalId, firstName, lastName, numberPhone, email, birthDate);
            //Console.WriteLine(employee.ToString() + "\n");
            return employee;
        }

        public static List<Employee> GenerateFutureEmployeePool(uint futureEmployeeCount)
        {
            List<Employee> futureEmployeeList = new List<Employee>();
            for (uint i = 0; i < futureEmployeeCount; i++)
            {
                futureEmployeeList.Add(GenerateFutureEmployee());
            }
            return futureEmployeeList;
        }

        public static Team GenerateTeam(string teamName)
        {
            Team team = new Team(teamName);
            team.Manager = GenerateFutureEmployee();
            team.AddEmployee(GenerateFutureEmployee());
            team.AddEmployee(GenerateFutureEmployee());
            team.AddEmployee(GenerateFutureEmployee());
            return team;
        }
        public static HumanResourceDepartment GenerateDepartment(DepartmentName departmentName)
        {
            // generate a department with two teams : team A, team B;
            HumanResourceDepartment department = new HumanResourceDepartment(departmentName, "");
            department.Director = GenerateFutureEmployee();
            department.AddTeam(GenerateTeam(departmentName + "Team A"));
            department.AddTeam(GenerateTeam(departmentName + "Team B"));
            return department;
        }

        public static Company GenerateCompany(string companyName)
        {
            Company company = new Company(companyName);
            company.ChiefExecutiveOfficer = GenerateFutureEmployee();
            company.AddDepartment(GenerateDepartment(DepartmentName.Development));
            company.AddDepartment(GenerateDepartment(DepartmentName.Finance));
            company.AddDepartment(GenerateDepartment(DepartmentName.Marketing));
            company.AddDepartment(GenerateDepartment(DepartmentName.HR));
            return company;
        }
    }
}