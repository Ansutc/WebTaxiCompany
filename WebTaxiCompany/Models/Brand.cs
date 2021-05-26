using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebTaxiCompany.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Car = new HashSet<Car>();
        }

        [Display(Name = "Код марки")]
        public long BrandKey { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Технические характеристики")]
        public string Specifications { get; set; }
        [Display(Name = "Стоимость")]
        public long Cost { get; set; }
        [Display(Name = "Специфика")]
        public string Specificity { get; set; }

        public virtual ICollection<Car> Car { get; set; }
    }
}
