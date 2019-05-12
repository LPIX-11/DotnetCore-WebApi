using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ClinicalApi.Models
{
    public class ClinicalApiContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        // public ClinicalApiContext(DbContextOptions<ClinicalApiContext> options)
        //     : base(options)
        // {
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=noreyni-X550LB\MSSQLSERVER;integrated security=true;database=ClinicalApi");
        }


    }

}