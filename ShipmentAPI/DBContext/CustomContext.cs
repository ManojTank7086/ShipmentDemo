using Microsoft.EntityFrameworkCore;
using ShipmentAPI.DBContext;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
//using ShipmentAPI.Models;

namespace ShipmentAPI.DBContext
{
    public partial class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {

        }

        //public override int SaveChanges()
        //{
        //    var selectedEntityList = ChangeTracker.Entries()
        //                            .Where(x => x.Entity is EntityInformation &&
        //                            (x.State == EntityState.Added || x.State == EntityState.Modified));

        //    //Gt user Name from  session or other authentication   
        //    var userName = "<Login UserName>";

        //    foreach (var entity in selectedEntityList)
        //    {

        //        ((EntityInformation)entity.Entity).ModifiedDate = DateTime.Now;
        //        ((EntityInformation)entity.Entity).ModifiedUserName = userName;
        //    }

        //    return base.SaveChanges();
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //        optionsBuilder.UseSqlServer("Data Source=Dev9;Initial Catalog=Demo;User ID=sa;Password=Sql@2023;Trust Server Certificate=True;Command Timeout=300");
        //    }
        //}

    }
}
