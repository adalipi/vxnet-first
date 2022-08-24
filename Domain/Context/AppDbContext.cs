﻿using vxnet.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace vxnet.Domain.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);

            builder.Entity<Shop>();//.HasIndex(i => i.Name).IsUnique();
        }
    }
}
