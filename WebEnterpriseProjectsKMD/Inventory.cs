using System;
using System.Collections.Generic;

namespace WebEnterpriseProjectsKMD
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateOnly? DateCreate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
