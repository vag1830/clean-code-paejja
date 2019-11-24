﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paella.Domain.Entities;
using Paella.Infrastructure.Entities;

namespace Paella.Infrastructure
{
    public class PaellaDbContext : IdentityDbContext<PaellaUser>
    {
        public DbSet<ProductDao> Products { get; set; }

        //public DbSet<OrderDao> Orders { get; set; }

        //public DbSet<OrderItemDao> OrderItems { get; set; }

        //public DbSet<CustomerDao> Customers { get; set; }

        public PaellaDbContext(DbContextOptions<PaellaDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductDao>(entity =>
            {
                entity.HasKey(product => product.Id);
            });


            //modelBuilder.Entity<OrderItemDao>(orderItem => { 
            //    orderItem.ha

            //    })
            //    .HasOne<ProductDao>();


        }
    }
}