namespace Movies.Domain.Entities
{
    public class Rating
    {
        public int UserID { get; private set; }

        public User User { get; private set; }

        public int MovieID { get; private set; }

        public Movie Movie { get; private set; }

        public int Value { get; private set; }

        private Rating()
        {

        }
    }
}
