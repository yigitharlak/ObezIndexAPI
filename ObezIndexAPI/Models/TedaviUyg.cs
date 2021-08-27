using System;
using System.Collections.Generic;

namespace ObezIndexAPI.Models
{
    public partial class TedaviUyg
    {
        public int DocId { get; set; }
        public int PatId { get; set; }
        public int IllId { get; set; }
        public DateTime TmtDate { get; set; }
    }
}
