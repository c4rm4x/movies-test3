using System.Collections.Generic;

namespace Movies.Domain.Entities
{
    public class Genre
    {
        public int GenreID { get; private set; }

        public string Name { get; private set; }

        public ICollection<MovieGenre> MovieGenres { get; private set; }

        private Genre()
        {
            MovieGenres = new HashSet<MovieGenre>();
        }
    }
}
