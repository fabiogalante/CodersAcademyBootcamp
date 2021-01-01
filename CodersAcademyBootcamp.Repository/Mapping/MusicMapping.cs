using CodersAcademyBootcamp.Domain.Album;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodersAcademy.API.Repository.Mapping
{
    public class MusicMapping : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.ToTable("Music");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.OwnsOne(x => x.Duration, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Duration");
            });
                    
        }
    }
}
