using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebTaxiCompany.Models
{
    public partial class Employee
    {
        public Employee()
        {
            CarEmployeeKeyNavigation = new HashSet<Car>();
            CarMechanicKeyEmployeeKeyNavigation = new HashSet<Car>();
        }

        [Display(Name = "Код сотрудника")]
        public long EmployeeKey { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Телефон")]
        public long Number { get; set; }
        [Display(Name = "Паспортные данные")]
        public long Passport { get; set; }
        [Display(Name = "Должность")]
        public long PositionKey { get; set; }
        [Display(Name = "Должность")]
        public virtual Position PositionKeyNavigation { get; set; }
        public virtual ICollection<Car> CarEmployeeKeyNavigation { get; set; }
        public virtual ICollection<Car> CarMechanicKeyEmployeeKeyNavigation { get; set; }
    }
}
