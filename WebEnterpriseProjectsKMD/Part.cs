using System;
using System.Collections.Generic;

namespace WebEnterpriseProjectsKMD
{
    public partial class Part
    {
        public int Id { get; set; }
        public string Position { get; set; } = null!;
        public string? DrawingNamber { get; set; }
        public string SteelProfil { get; set; } = null!;
        public int Length { get; set; }
        public double Weight { get; set; }
        public string SteelMaterial { get; set; } = null!;
        public double? PaintingArea { get; set; }
        public string? Note { get; set; }
        public string? GostProfile { get; set; }
        public int InventorieId { get; set; }
        public int IsRolledSteel { get; set; }
    }
}
