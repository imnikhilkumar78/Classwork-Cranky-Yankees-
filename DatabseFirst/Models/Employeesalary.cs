using System;
using System.Collections.Generic;

#nullable disable

namespace DatabseFirst.Models
{
    public partial class Employeesalary
    {
        public int EmpId { get; set; }
        public int? SalId { get; set; }
        public DateTime? Date { get; set; }
        public double? Extra { get; set; }
        public DateTime? Saldate { get; set; }

        public virtual Salary Sal { get; set; }
    }
}
