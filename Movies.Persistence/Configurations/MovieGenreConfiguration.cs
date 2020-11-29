using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;

namespace Movies.Persistence.Configurations
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.ToTable("MovieGenres");
            builder.HasKey(e => new { e.MovieID, e.GenreID });
            builder.HasOne(e => e.Movie)
                .WithMany(e => e.MovieGenres)
                .HasForeignKey(e => e.MovieID);
            builder.HasOne(e => e.Genre)
                .WithMany(e => e.MovieGenres)
                .HasForeignKey(e => e.GenreID);
        }
    }
}
