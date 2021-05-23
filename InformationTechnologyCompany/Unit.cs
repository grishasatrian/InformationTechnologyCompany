using System;
using System.Collections.Generic;
using System.Text;


namespace InformationTechnologyCompany
{
    public enum UnitType 
    {
        Undefined,
        Company,
        Department,
        Team​
        //Project
    }
    public class Unit<T> : IReportable
    {
        string unitId = CompanyUtil.GetGuid();
        UnitType unitType;

        DateTime createDate = DateTime.UtcNow;
        DateTime updateDate;
        DateTime endDate;

        int minCapacity = 1;
        int maxCapacity = 100;
        int size;
        string name;
        Employee head;
        List<T> memberList = new List<T>();

        public Unit(string name, UnitType unitType, int minCapacity, int maxCapacity)
        {
            this.name = name;
            this.unitType = unitType;
            this.minCapacity = minCapacity;
            this.maxCapacity = maxCapacity;
        }
        public Unit(string name, UnitType unitType)
        {
            this.name = name;
            this.unitType = unitType;
        }
        public Unit(string name, UnitType unitType, List<T> list)
        {
            this.name = name;
            this.unitType = unitType;
            this.memberList = list;
        }
        protected DateTime CreateDate { get => createDate; }
        protected DateTime UpdateDate { get => updateDate; set => updateDate = value; }
        protected DateTime EndDate { get => endDate; }
        protected string UnitId { get => unitId; }
        protected UnitType UnitType { get => unitType; }
        protected int MinCapacity { get => minCapacity; set => minCapacity = value; }
        protected int MaxCapacity { get => maxCapacity; set => maxCapacity = value; }
        protected int Size { get => memberList.Count; }
        protected string Name { get => name; set => name = value; }
        protected List<T> MemberList { get => memberList; }
        protected Employee Head { get => head; set => head = value; }

        protected bool AddMember(T member, bool updateMaxCapacity)
        {
            if (this.memberList.Contains(member))
            {
                return false;
            }
            if (memberList.Count == this.maxCapacity)
            {
                if (updateMaxCapacity)
                {
                    this.maxCapacity = memberList.Count + 1;
                }
                else
                {
                    return false;
                }
            }
            // add the member
            memberList.Add(member);
            // update the timestamp
            updateDate = DateTime.UtcNow;

            return true;
        }
        protected bool RemoveMember(T member, bool updateMinCapacity)
        {
            if (!this.memberList.Contains(member))
            {
                return false;
            }
            if (memberList.Count == this.minCapacity)
            {
                if (updateMinCapacity)
                {
                    this.minCapacity = memberList.Count - 1;
                }
                else
                {
                    return false;
                }
            }
            // remove the member
            memberList.Remove(member);
            // update the timestamp
            updateDate = DateTime.UtcNow;

            return true;
        }

        override
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string uType = this.unitType.ToString();
            sb.AppendFormat("{0} name is {1}", uType, this.name).AppendLine();
            sb.AppendFormat("{0} members are:", uType).AppendLine();
            foreach (var member in this.memberList)
            {
                sb.Append(member.ToString()).AppendLine();
            }
            
            return sb.ToString();
        }

        public void GenerateReport()
        {
            Console.WriteLine(this.ToString());
        }

        
        
    }
}
