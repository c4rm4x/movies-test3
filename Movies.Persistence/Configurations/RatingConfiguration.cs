using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;

namespace Movies.Persistence.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Ratings");
            builder.HasKey(e => new { e.MovieID, e.UserID });
            builder.HasOne(e => e.User)
                .WithMany(e => e.Ratings)
                .HasForeignKey(e => e.UserID);
            builder.HasOne(e => e.Movie)
                .WithMany(e => e.Ratings)
                .HasForeignKey(e => e.MovieID);
        }
    }
}
