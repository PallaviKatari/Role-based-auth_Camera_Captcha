﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Role_based_auth.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}