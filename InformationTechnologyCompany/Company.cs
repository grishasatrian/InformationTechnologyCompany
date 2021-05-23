using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public class Company : Unit<Department>
    {
        Employee chiefExecutiveOfficer;
        public Company(string name) : base(name, UnitType.Company)
        {

        }

        public Employee ChiefExecutiveOfficer
        {
            get => chiefExecutiveOfficer;
            set
            {
                chiefExecutiveOfficer = value;
                this.Head = value;
            }
        }

        public void AddDepartment(Department department)
        {
            department.CompanyId = this.UnitId;
            this.AddMember(department, true);
        }

        public void RemoveDepartment(Department department)
        {
            department.CompanyId = this.UnitId;
            this.RemoveMember(department, true);
        }
    }
}
