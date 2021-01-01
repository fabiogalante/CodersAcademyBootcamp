using CodersAcademyBootcamp.Domain.Album;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodersAcademyBootcamp.Repository.Mapping
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albuns");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Backdrop).IsRequired();

            builder.OwnsOne(x => x.Band, p =>
            {
                p.Property(f => f.Name).HasColumnName("Band");
            });

            builder.HasMany(x => x.Musics).WithOne().OnDelete(DeleteBehavior.Cascade);

        }
    }
}
