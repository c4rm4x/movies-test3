using System;
using System.Collections.Generic;

namespace Movies.Domain.Entities
{
    public class Movie
    {
        public int MovieID { get; private set; }

        public string Title { get; private set; }

        public int YearOfRelease { get; private set; }

        public int RunningTime { get; private set; }

        public decimal AverageRating { get; private set; }

        public ICollection<MovieGenre> MovieGenres { get; private set; }

        public ICollection<Rating> Ratings { get; private set; }

        private Movie()
        {
            MovieGenres = new HashSet<MovieGenre>();
            Ratings = new HashSet<Rating>();
        }

        public decimal AverageRatingClosest05 => Math.Round(AverageRating * 2, MidpointRounding.AwayFromZero) / 2;
    }
}
