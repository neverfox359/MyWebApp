using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MyWeb.DAL
{
    public class SportContext : DbContext
    {
        public SportContext() : base("SportContext")
        {
        }

        public DbSet<Sportsman> Sportsmans { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
    }
}