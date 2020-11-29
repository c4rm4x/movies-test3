# movies-test3

## Overall solution

The solution uses MediatR and FluentValidation all running in .Net Core + EF Core.

A localDB will be created, called Movies, once the migrations/seed run. To run the migration, use Update-Database command using Movies.Persistence project as the target one.

Some unit tests have being written to test validations and MediatR handlers. The other handlers were not tested, but their tests looke like similar to the one created for SearchQueryHandler.

Also some acceptance tests using Specflow have been added to make sure the API specifications are met.



## Things left.
The MoviesRatingService has been left pending to be implemented, as the whole idea would be to raise an event, and then to have some functionality adding (or updating) the user's rates plus updating the average rating for the given movie. At least, if this solution sounds too complex for the current state, it could be easily replaced with an stored procedure to MERGE ratings table + update statement to update movie's average rating.
