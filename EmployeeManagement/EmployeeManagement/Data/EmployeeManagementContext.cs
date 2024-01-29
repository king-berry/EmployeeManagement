﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;

namespace EmployeeManagement.Data
{
    public class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext (DbContextOptions<EmployeeManagementContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeManagement.Models.Employee_Tbl> Employee_Tbl { get; set; } = default!;
        public DbSet<EmployeeManagement.Models.Department_Tbl> Department_Tbl { get; set; } = default!;
    }
}
