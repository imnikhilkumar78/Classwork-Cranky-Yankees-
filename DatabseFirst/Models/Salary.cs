using System;
using System.Collections.Generic;

#nullable disable

namespace DatabseFirst.Models
{
    public partial class Salary
    {
        public Salary()
        {
            Employeesalaries = new HashSet<Employeesalary>();
        }

        public int SalId { get; set; }
        public double? Basic { get; set; }
        public double? Hra { get; set; }
        public double? Da { get; set; }
        public double? Deductions { get; set; }

        public virtual ICollection<Employeesalary> Employeesalaries { get; set; }
    }
}
