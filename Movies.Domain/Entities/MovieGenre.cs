namespace Movies.Domain.Entities
{
    public class MovieGenre
    {
        public int MovieID { get; private set; }

        public Movie Movie { get; private set; }

        public int GenreID { get; private set; }

        public Genre Genre { get; private set; }

        private MovieGenre()
        {

        }
    }
}
