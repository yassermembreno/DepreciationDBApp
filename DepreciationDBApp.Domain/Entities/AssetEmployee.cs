using System;
using System.Collections.Generic;

#nullable disable

namespace DepreciationDBApp.Domain.Entities
{
    public partial class AssetEmployee
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
