using DerayatiBank.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerayatiBank.Core.DbContexts
{
    public class CustomersMapConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builer)
        {
            builer.ToTable("Customers");
            builer.HasKey(user => user.Id);
            //builer.Property(user => user.DateOfBirth).HasColumnName("DateOfBirth");
            builer.OwnsOne(c => c.Name, NavigationBuilder => { NavigationBuilder.Property(hash => hash.FirstName); NavigationBuilder.Property(hash => hash.LastName); });
            builer.OwnsOne(c => c.Email, NavigationBuilder => { NavigationBuilder.Property(hash => hash.Address).HasColumnName("Email").IsRequired(); });
            builer.OwnsOne(c => c.PhoneNumber, sb =>
            {
                sb.Property(x => x.Number).HasMaxLength(255);
                sb.Property(x => x.CountryCode).HasMaxLength(255);
            });


        }
    }
}
