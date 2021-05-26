using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebTaxiCompany.Models
{
    public partial class Call
    {
        [Display(Name = "Номер")]
        public int NumKey { get; set; }
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
        [Display(Name = "Время")]
        public DateTime Time { get; set; }
        [Display(Name = "Телефон")]
        public long Number { get; set; }
        [Display(Name = "Откуда")]
        public long WhereFrom { get; set; }
        [Display(Name = "Куда")]
        public long WhereTo { get; set; }
        [Display(Name = "Тариф")]
        public long RateKey { get; set; }
        [Display(Name = "Автомобиль")]
        public long CarKey { get; set; }
        [Display(Name = "Услуга")]
        public long AddServiceKey { get; set; }
        [Display(Name = "Сотрудник-оператор")]
        public long EmployeeKey { get; set; }
        [Display(Name = "Услуга")]
        public virtual AddService AddServiceKeyNavigation { get; set; }
        [Display(Name = "Автомобиль")]
        public virtual Car CarKeyNavigation { get; set; }
        [Display(Name = "Сотрудник-оператор")]
        public virtual Employee EmployeeKeyNavigation { get; set; }
        [Display(Name = "Тариф")]
        public virtual Rate RateKeyNavigation { get; set; }
    }
}
