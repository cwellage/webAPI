using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;

namespace DataLayer
{
    public class MyDB : DbContext
    {
        public MyDB() : base()
        {

        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public List<Department> GetAllDepartments()
        {
            return Departments.ToList();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlServer("Server=tcp:cwellageserver.database.windows.net,1433;Initial Catalog=Chatura;Persist Security Info=False;User ID=cwellage;Password=Aravinda1985#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", providerOptions => providerOptions.CommandTimeout(60)).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // Azure
            builder.UseSqlServer("Data Source = host.docker.internal,1433; Initial Catalog = chatura;User id=sa; Password=Sa1234;", sqlServerOptionsAction: sqloptions => { sqloptions.EnableRetryOnFailure();}).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //builder.UseSqlServer("Data Source = 104.154.91.119; Initial Catalog = chatura; User id=cw; Password=Cw1234;", providerOptions => providerOptions.CommandTimeout(60)).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // google cloud 


        }
    }
}