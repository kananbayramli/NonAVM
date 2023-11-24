﻿using ECommerse.Core.Entities;
using ECommerse.Core.Enums;
using ECommerse.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s
{
    public class AdressDTO : BaseDTO
    {
        public string UserID { get; set; } = null!;
        public AppUser User { get; set; } = null!;

        public ICollection<Order>? Orders { get; set; }

        public string AdressLine1 { get; set; } = null!;
        public string? AdressLine2 { get; set; }
        public City City { get; set; }
        public bool IsDefault { get; set; }
        public string? PostalCode { get; set; }
    }
}