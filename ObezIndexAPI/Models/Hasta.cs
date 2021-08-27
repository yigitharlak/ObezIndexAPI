using System;
using System.Collections.Generic;

namespace ObezIndexAPI.Models
{
    public partial class Hasta
    {
        public int PatId { get; set; }
        public string PatName { get; set; }
        public string PatUsername { get; set; }
        public string PatPassword { get; set; }
        public int PatHeight { get; set; }
        public int PatWeight { get; set; }
        public int PatAge { get; set; }
        public string PatGender { get; set; }
        public string PatAddress { get; set; }
        public string PatInfo { get; set; }
    }
}
