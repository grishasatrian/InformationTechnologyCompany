using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public enum DepartmentName
    {
         Undefined,
         Marketing,
         Finance,
         ProjectManagement,
         Development,
         QualityAssurance,
         HR
    }
    public class Department : Unit<Team>
    {
        Employee director;
        string companyId;

        public Department(DepartmentName departmentName, string companyId) : base(departmentName.ToString(), UnitType.Department)
        {
            this.companyId = companyId;
        }

        public Department(DepartmentName departmentName) : base(departmentName.ToString(), UnitType.Department)
        {
            
        }

        public Employee Director 
        {
            get => director;
            set
            { 
                director = value;
                this.Head = value;
            }
        }
        public string CompanyId { get => companyId; set => companyId = value; }
        
    }
}
