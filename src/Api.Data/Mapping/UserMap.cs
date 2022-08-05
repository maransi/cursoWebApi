using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey( u => u.Id );

            builder.HasIndex( u => u.Email );

            builder.Property( u => u.Nome )
                    .HasColumnName("Nome")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(60)
                    .IsRequired();

            builder.Property( u => u.Email )
                    .HasColumnName("Email")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property( u => u.CreatedAt )
                    .HasColumnName("CreatedAt")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}