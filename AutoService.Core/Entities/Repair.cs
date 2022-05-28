using AutoService.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Core.Entities
{
    public class Repair:BaseEntity
    {
        public int RepairId { get; set; }

        public int RepairStatus = 0;
    }
}
