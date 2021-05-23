using InformationTechnologyCompany;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Main.cs
{
    public partial class MainForm : Form, IHumanResourceDepartment
    {
        public MainForm()
        {
            InitializeComponent();
            comboSpecialistType.DataSource = Enum.GetValues(typeof(SpecialistType));
            comboQualificationLevel.DataSource = Enum.GetValues(typeof(QualificationLevel));
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHire_Click(object sender, EventArgs e)
        {        
            
        }

        public void Hire(Team team, SpecialistType specialistType, QualificationLevel qualificationLevel, string personalId, string firstName, string lastName, string numberPhone, string email, DateTime birthDate)
        {
            
        }

        public void Fire(Team team, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
