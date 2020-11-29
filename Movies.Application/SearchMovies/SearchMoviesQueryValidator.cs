using FluentValidation;
using FluentValidation.Validators;
using System.Linq;

namespace Movies.Application.SearchMovies
{
    public class SearchMoviesQueryValidator : AbstractValidator<SearchMoviesQuery>
    {
        public SearchMoviesQueryValidator()
        {
            RuleFor(e => e.Filter).NotNull().SetValidator(new SearchFilterValidator());
        }
    }

    internal class SearchFilterValidator : PropertyValidator
    {
        public SearchFilterValidator() : base("At least one filter criteria must be provided")
        {

        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var searchFilter = context.PropertyValue as SearchFilter;

            return IsValid(searchFilter);
        }

        private bool IsValid(SearchFilter searchFilter) => 
            !string.IsNullOrEmpty(searchFilter.Title) ||
            searchFilter.YearOfRelease.HasValue ||
            searchFilter.Genres.Any(g => !string.IsNullOrEmpty(g));
    }
}
