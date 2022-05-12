using System;
using System.Collections.Generic;

#nullable disable

namespace DepreciationDBApp.Domain.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            AssetEmployees = new HashSet<AssetEmployee>();
        }

        public int Id { get; set; }
        public string Names { get; set; }
        public string Lastnames { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Dni { get; set; }
        public string Status { get; set; }

        public virtual ICollection<AssetEmployee> AssetEmployees { get; set; }
    }
}
