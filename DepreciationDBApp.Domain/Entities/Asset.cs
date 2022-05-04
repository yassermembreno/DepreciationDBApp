using System;
using System.Collections.Generic;

#nullable disable

namespace DepreciationDBApp.Domain.Entities
{
    public partial class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountResidual { get; set; }
        public int Terms { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
    }
}
