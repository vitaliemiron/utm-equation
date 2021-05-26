using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UTMAPP.Models
{
    public partial class CalcValue
    {
        [Key]
        public int Id { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double x1 { get; set; }
        public double x2 { get; set; }
    }
}
