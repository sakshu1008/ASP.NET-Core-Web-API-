using CRUDOp1.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDOp1.Data
{
    public class EmployeeAPIDbContext : DbContext
    {
        public EmployeeAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }
    }
}
