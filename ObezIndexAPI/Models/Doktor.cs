using System;
using System.Collections.Generic;

namespace ObezIndexAPI.Models
{
    public partial class Doktor
    {
        public int DocId { get; set; }
        public string DocName { get; set; }
        public string DocTitle { get; set; }
        public string DocProfession { get; set; }
        public string DocAddress { get; set; }
        public string DocInfo { get; set; }
        public string DocUsername { get; set; }
        public string DocPassword { get; set; }
    }
}
