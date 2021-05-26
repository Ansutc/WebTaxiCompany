using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebTaxiCompany.Models
{
    public partial class Position
    {
        public Position()
        {
            Employee = new HashSet<Employee>();
        }

        [Display(Name = "Код должности")]
        public long PositionKey { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Оклад")]
        public long Salary { get; set; }
        [Display(Name = "Обязанности")]
        public string Responsibility { get; set; }
        [Display(Name = "Требования")]
        public string Requirement { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
