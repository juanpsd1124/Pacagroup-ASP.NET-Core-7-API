using Pacagroup.Ecommerce.Domain.Common;
using Pacagroup.Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Domain.Entities.Descuento
{
    public class Discount : BaseAuditableEntity
    {
        public string Name {get; set;}

        public string Description { get; set; }

        public decimal Percent { get; set; }

        public DiscountStatus Status { get; set; }


    }
}
