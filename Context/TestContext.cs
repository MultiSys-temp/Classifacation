﻿using Classifacation.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifacation.Context
{
    public class TestContext : DbContext
    {
        public TestContext()
            : base("name=ClassificationLogDb")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            var initializer = new TestDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
        }

        public DbSet<Event> Events { get; set; }
    }

    public class ModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfigurePersonEntity(modelBuilder);

        }


        private static void ConfigurePersonEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>();
        }
    }
}
