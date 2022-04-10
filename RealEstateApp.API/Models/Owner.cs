﻿using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstateApp.API.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Properties = new HashSet<Property>();
        }

        public int IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Bithday { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
