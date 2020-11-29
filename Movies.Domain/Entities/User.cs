using System.Collections.Generic;

namespace Movies.Domain.Entities
{
    public class User
    {
        public int UserID { get; private set; }

        public string Username { get; private set; }

        public ICollection<Rating> Ratings { get; private set; }

        private User()
        {
            Ratings = new HashSet<Rating>();
        }
    }
}
