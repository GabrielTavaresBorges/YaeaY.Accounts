using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YaeaY.Account.Domain.Entities.UserDocuments;

namespace YaeaY.Account.Infrastructure.Data.Mappings.UserDocuments;

public sealed class UserDocumentMap : IEntityTypeConfiguration<UserDocument>
{
    public void Configure(EntityTypeBuilder<UserDocument> builder)
    {
        builder.ToTable("UserDocuments");
        builder.HasKey(h => h.Id);

        // === UserId ===
        builder.Property<Guid>("UserId")
            .HasColumnName("UserId")
            .IsRequired();
        builder.HasIndex("UserId");

        // ===== DocumentType =====
        builder.Property(p => p.DocumentType)
            .HasColumnName("DocumentType")
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        // ===== DocumentNumber =====
        builder.Property(p => p.DocumentNumber)
            .HasColumnName("DocumentNumber")
            .HasMaxLength(50)
            .IsRequired();

        // ===== CreatedAt =====
        builder.Property(p => p.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired();
    }
}
