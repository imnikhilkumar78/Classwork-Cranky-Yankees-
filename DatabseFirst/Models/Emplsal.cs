using System;
using System.Collections.Generic;

#nullable disable

namespace DatabseFirst.Models
{
    public partial class Emplsal
    {
        public int? Empid { get; set; }
        public int? SalId { get; set; }
        public DateTime? SalDate { get; set; }
        public double? TotalSal { get; set; }

        public virtual Tblemp1 Emp { get; set; }
        public virtual Salary Sal { get; set; }
    }
}
