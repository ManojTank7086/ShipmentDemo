using Microsoft.EntityFrameworkCore;
using ShipmentModel.DBContext;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
//using ShipmentAPI.Models;

namespace ShipmentModel.DBContext
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

    }
}
