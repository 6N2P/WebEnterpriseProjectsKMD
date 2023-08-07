using System;
using System.Collections.Generic;

namespace WebEnterpriseProjectsKMD
{
    public partial class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string? CompasName { get; set; }
    }
}
