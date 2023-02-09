using DemoPRN.Models;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
    {
    }
 

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder optionsBuilder)
    {
        optionsBuilder.Entity<Company>().HasData(
            new Company { Id = Guid.NewGuid(), Name = "FPT SoftWare" , Address = "Ha Noi" ,Country = "Viet Nam"},
            new Company { Id = Guid.NewGuid(), Name = "NTQ" , Address = "Ha Noi" ,Country = "Viet Nam"},
            new Company { Id = Guid.NewGuid(), Name = "Base Vn" , Address = "Ha Noi" ,Country = "Viet Nam"},
            new Company { Id = Guid.NewGuid(), Name = "Nash Tech" , Address = "Ha Noi" ,Country = "Viet Nam"}
        );
    }
}