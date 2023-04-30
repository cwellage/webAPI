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
            builder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = chatura; Integrated Security = True", providerOptions => providerOptions.CommandTimeout(60)).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}