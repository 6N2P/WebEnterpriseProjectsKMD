using System;
using System.Collections.Generic;

namespace WebEnterpriseProjectsKMD
{
    public partial class MarksRow
    {
        public int Id { get; set; }
        public int MarkId { get; set; }
        public int PositionId { get; set; }
        public int Amount { get; set; }
        public int? AmountT { get; set; }
        public int? AmoubtN { get; set; }
        public double? Weight { get; set; }
        public double? TotalWeight { get; set; }
        public double? Area { get; set; }
        public double? TotalArea { get; set; }
    }
}
