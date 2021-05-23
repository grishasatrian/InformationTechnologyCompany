using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public interface IBugReport
    {
        void Create(string createById, string title, string description);
        void Update(string createById, string title, string description);
    }
}
