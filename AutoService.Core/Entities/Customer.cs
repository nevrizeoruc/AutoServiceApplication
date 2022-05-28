using AutoService.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Core.Entities
{
    public class Customer: BaseEntity
    {
        [Required(ErrorMessage = "Müşteri adı zorunludur!")]
        [MaxLength(50, ErrorMessage = "Müşteri adı 50 karakterden fazla olamaz!")]
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerGsm { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}
