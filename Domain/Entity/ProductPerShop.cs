﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vxnet.DTOs.Enums;

namespace vxnet.Domain.Entity
{
    public class ProductPerShop :BaseEntity
    {
        [Key, Column(Order = 0)]
        public Guid ProductId { get; set; }
        
        [Key, Column(Order = 1)]
        public Guid ShopId { get; set; }

        public double Price { get; set; }
        public string Currency { get; set; }

        public ProductAvailability Available { get; set; }
        
        public virtual Shop? Shop { get; set; }
        public virtual Product? Product { get; set; }

    }


    
}