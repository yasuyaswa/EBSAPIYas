using System;
using System.Collections.Generic;

namespace EBSYas.Models
{
    public partial class Customer
    {
        public decimal CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public decimal CustomerMobile { get; set; }
        public string CustomerPassword { get; set; } = null!;
        public string CustomerAddress { get; set; } = null!;
    }
    public class Signin
    {
        public string? CustomerEmail { get; set; }
        public string CustomerPassword { get; set; } = null!;
    }

}
