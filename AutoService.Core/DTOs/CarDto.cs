using AutoService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Core.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string CarColor { get; set; }
        public string CarYear { get; set; }
        public decimal Prise { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
