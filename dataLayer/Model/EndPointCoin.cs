using System;
using System.Collections.Generic;

namespace dataLayer.Model
{
    public partial class EndPointCoin
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? History { get; set; }
        public string? Time { get; set; }
    }
}
