using System;
using System.Collections.Generic;

namespace WebEnterpriseProjectsKMD
{
    public partial class Sortament
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string Name { get; set; } = null!;
        public double Density { get; set; }
        public int GostId { get; set; }
        public double? Area { get; set; }
    }
}
