using ConsoleApp01.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp01.Models.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Active)
            .IsRequired(true)
            .HasColumnName("Active");

        builder.Property(x => x.Notes)
            .HasMaxLength(1024)
            .IsRequired(false)
            .HasColumnName("Notes");

        builder.OwnsOne(x => x.Email).Property(x => x.Address).IsRequired(true).HasColumnName("Email");
        builder.OwnsOne(x => x.Email).Property(x => x.Verified).IsRequired(true).HasColumnName("EmailVerified");
        builder.OwnsOne(x => x.Email).Property(x => x.VerificationCode).IsRequired(true)
            .HasColumnName("EmailVerificationCode");
        builder.OwnsOne(x => x.Email).Property(x => x.VerificationCodeExpireDate).IsRequired(true)
            .HasColumnName("EmailVerificationCodeExpireDate");

        // builder.Property(x => x.Email.Address).IsRequired(true).HasColumnName("Email");
        // builder.Property(x => x.Email.Verified).IsRequired(true).HasColumnName("EmailVerified");
        // builder.Property(x => x.Email.VerificationCode).IsRequired(true).HasColumnName("EmailVerificationCode");
        // builder.Property(x => x.Email.VerificationCodeExpireDate).IsRequired(true)
        //     .HasColumnName("EmailVerificationCodeExpireDate");

        builder.Property(x => x.PasswordHash)
            .HasMaxLength(1024)
            .IsRequired(true);

        builder.OwnsOne(x => x.Tracker)
            .Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired(true)
            .HasColumnType("SMALLDATETIME");

        builder.OwnsOne(x => x.Tracker)
            .Property(x => x.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .IsRequired(true)
            .HasColumnType("SMALLDATETIME");
    }
}