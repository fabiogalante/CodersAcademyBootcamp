using CodersAcademyBootcamp.Domain.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Repository.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Photo).IsRequired().HasMaxLength(500);
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.OwnsOne(x => x.CPF, p =>
            {
                p.Property(f => f.Valor).HasColumnName("CPF");
            });

            builder.OwnsOne(x => x.Email, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Email");
            });


        }
    }
}
