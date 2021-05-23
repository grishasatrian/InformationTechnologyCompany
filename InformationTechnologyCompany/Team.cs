using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public class Team : Unit<Employee>
    {
        Employee manager;
        string departmentId;
        string companyId;
        public Team(string name, string departmentId, string companyId) : base(name, UnitType.Team)
        {
            this.companyId = companyId;
            this.departmentId = departmentId;
        }
        public Team(string name) : base(name, UnitType.Team)
        {
            
        }

        public Employee Manager
        {
            get => manager;
            set
            {
                manager = value;
                this.Head = value;
            }
        }
        public string DepartmentId { get => departmentId; set => departmentId = value; }
        public string CompanyId { get => companyId; set => companyId = value; }

        public void AddEmployee(Employee employee)
        {
            employee.CompanyId = this.companyId;
            employee.DepartmentId = this.departmentId;
            employee.TeamId = this.UnitId;
            this.AddMember(employee, true);
        }
        
        public void RemoveEmployee(Employee employee)
        {
            employee.CompanyId = this.companyId;
            employee.DepartmentId = this.departmentId;
            employee.TeamId = this.UnitId;
            this.RemoveMember(employee, true);
        }
    }
}
