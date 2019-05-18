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
            // Modify the connection strings according to your server
            optionsBuilder.UseSqlServer(@"Server=.;Initial Catalog=ClinicalApi; User ID=admin; Password=clinical@Passwd1");
        }


    }

}