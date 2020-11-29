using MediatR;
using System.Collections.Generic;

namespace Movies.Application.SearchMovies
{
    public class SearchMoviesQuery : IRequest<SearchMoviesQueryResponse>
    {
        public SearchFilter Filter { get; private set; }

        private SearchMoviesQuery()
        {

        }

        public SearchMoviesQuery(string title, int? yearOfRelease, IEnumerable<string> genres)
        {
            Filter = new SearchFilter(title, yearOfRelease, genres);
        }
    }

    public class SearchFilter
    {
        public string Title { get; private set; }

        public IEnumerable<string> Genres { get; private set; }

        public int? YearOfRelease { get; private set; }

        private SearchFilter()
        {

        }

        public SearchFilter(string title, int? yearOfRelease, IEnumerable<string> genres)
        {
            Title = title;
            YearOfRelease = yearOfRelease;
            Genres = genres;
        }
    }
}
