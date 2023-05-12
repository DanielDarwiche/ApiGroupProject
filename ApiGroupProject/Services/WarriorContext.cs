using Library;
using Microsoft.EntityFrameworkCore;

namespace ApiGroupProject.Services
{
    public class WarriorContext : DbContext
    {

        public WarriorContext(DbContextOptions<WarriorContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            // Seed Data
            // Employee
            mb.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                EmployeeName = "Damir",
                ProjectId = 1
            });
            mb.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                EmployeeName = "Daniel",
                ProjectId = 2
            });
            mb.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                EmployeeName = "Filip",
                ProjectId = 3
            });
            mb.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                EmployeeName = "Anas",
                ProjectId = 1
            });
            mb.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 5,
                EmployeeName = "Alvin",
                ProjectId = 3
            });

            // Project
            mb.Entity<Project>().HasData(new Project
            {
                ProjectId = 1,
                ProjectName = "Group1"
            });
            mb.Entity<Project>().HasData(new Project
            {
                ProjectId = 2,
                ProjectName = "Group2"
            });
            mb.Entity<Project>().HasData(new Project
            {
                ProjectId = 3,
                ProjectName = "Group3"
            });

            // TimeReport
            mb.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 1,
                EmployeeId = 2,
                Week = 15,
                Hours = 8
            });
            mb.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 2,
                EmployeeId = 2,
                Week = 10,
                Hours = 20
            });
            mb.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 3,
                EmployeeId = 3,
                Week = 40,
                Hours = 40
            });
            mb.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 4,
                EmployeeId = 5,
                Week = 18,
                Hours = 32
            });
            mb.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 5,
                EmployeeId = 4,
                Week = 36,
                Hours = 37
            });
            mb.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 6,
                EmployeeId = 4,
                Week = 14,
                Hours = 40
            });
        }
    }
}