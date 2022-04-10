using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstateApp.API.Models
{
    public partial class PropertyImage
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public string FileB64 { get; set; }
        public bool Enabled { get; set; }

        public virtual Property IdPropertyNavigation { get; set; }
    }
}
