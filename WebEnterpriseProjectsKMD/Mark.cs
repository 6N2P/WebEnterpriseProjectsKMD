using System;
using System.Collections.Generic;

namespace WebEnterpriseProjectsKMD
{
    public partial class Mark
    {
        public int Id { get; set; }
        public string Marka { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int? Amount { get; set; }
        public double? Weight { get; set; }
        public double? TotalWeight { get; set; }
        public double? Area { get; set; }
        public double? TotalArea { get; set; }
        public double OrderId { get; set; }
        public int? MetizId { get; set; }
        public int? AmountMetiz { get; set; }
        public bool? IsWelding { get; set; }
        public string? DrawingNamber { get; set; }
        public string? Coating { get; set; }
        public int? PriecesMade { get; set; }
    }
}
