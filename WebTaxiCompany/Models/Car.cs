using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebTaxiCompany.Models
{
    public partial class Car
    {
        [Display(Name = "Код автомобиля")]
        public long CarKey { get; set; }
        [Display(Name = "Код марки")]
        public long BrandKey { get; set; }
        [Display(Name = "Регистрационный номер")]
        public long RegistrationNumber { get; set; }
        [Display(Name = "Номер кузова")]
        public long BodNumber { get; set; }
        [Display(Name = "Номер двигателя")]
        public long EngineNumber { get; set; }
        [Display(Name = "Год выпуска")]
        public DateTime YearOfIssue { get; set; }
        [Display(Name = "Пробег")]
        public long Mileage { get; set; }
        [Display(Name = "Сотрудника-шофёр")]
        public long EmployeeKey { get; set; }
        [Display(Name = "Дата последнего ТО")]
        public DateTime MaintenanceDate { get; set; }
        [Display(Name = "Сотрудник-механик")]
        public long MechanicKeyEmployeeKey { get; set; }
        [Display(Name = "Специальные отметки")]
        public string SpecialMarks { get; set; }
        [Display(Name = "Марка")]
        public virtual Brand BrandKeyNavigation { get; set; }
        [Display(Name = "Сотрудника-шофёр")]
        public virtual Employee EmployeeKeyNavigation { get; set; }
        [Display(Name = "Сотрудник-механик")]
        public virtual Employee MechanicKeyEmployeeKeyNavigation { get; set; }
    }
}
