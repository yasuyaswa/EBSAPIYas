using System;
using System.Collections.Generic;

namespace EBSYas.Models
{
    public partial class Admin
    {
        public decimal AdminId { get; set; }
        public string AdminUsername { get; set; } = null!;
        public string AdminPassword { get; set; } = null!;
        public int AdminId1 { get; set; }
    }
    public class SignIn
    {
        public string? AdminUsername { get; set; }
        public string AdminPassword { get; set; } = null!;
    }


}
