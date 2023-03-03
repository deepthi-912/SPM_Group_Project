using System;
using System.Collections.Generic;
using HWK4.Models;
using Microsoft.EntityFrameworkCore;

namespace HWK4.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Appointments> Appointments { get; set; }
    }
}

