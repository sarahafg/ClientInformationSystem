using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data
{
    public class ClientInformationSystemDbContext : DbContext
    {
        // get the connection string into constructor
        public ClientInformationSystemDbContext(DbContextOptions<ClientInformationSystemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // specify Fluent API rules for your Entities

            modelBuilder.Entity<Client>(ConfigureClient);
            modelBuilder.Entity<Interaction>(ConfigureInteraction);
            modelBuilder.Entity<Employee>(ConfigureEmployee);
        }

        private void ConfigureClient(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Phones).HasMaxLength(30);
            builder.Property(c => c.Email).HasMaxLength(50);
            builder.Property(c => c.Address).HasMaxLength(100);
            builder.Property(c => c.AddedOn).HasDefaultValueSql("getdate()");

        }
        private void ConfigureInteraction(EntityTypeBuilder<Interaction> builder)
        {
            builder.ToTable("Interactions");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.ClientId);
            builder.Property(i => i.EmployeeId);
            builder.Property(i => i.IntType).HasMaxLength(1);
            builder.Property(i => i.IntDate).HasDefaultValueSql("getdate()");
            builder.Property(i => i.Remarks).HasMaxLength(500);
            //builder.HasBaseType(Char)
        }

        private void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Password).HasMaxLength(10);
            builder.Property(e => e.Designation).HasMaxLength(50);
        }


        public DbSet<Client> Clients { get; set; }

        public DbSet<Interaction> Interactions { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
