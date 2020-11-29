using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movies.Application.SearchMovies;
using Movies.Application.Tests.Internal;
using Movies.Domain.Entities;
using Movies.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Tests.SearchMovies
{
    [TestClass]
    public class SearchMoviesQueryHandlerTests
    {
        private Mock<IMovieRepository> _mockMovies;
        private SearchMoviesQueryHandler Sut;

        [TestInitialize]
        public void Setup()
        {
            _mockMovies = new Mock<IMovieRepository>();

            Sut = new SearchMoviesQueryHandler(_mockMovies.Object);

            _mockMovies
                .Setup(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(BuilderCollection.Generate<Movie>());
        }

        [TestMethod]
        public async Task Handle_Should_Search_Movies_With_Given_Criteria()
        {
            var request = new SearchMoviesQueryBuilder().Build();

            await Sut.Handle(request, default);

            _mockMovies.Verify(m => m.SearchAsync(request.Filter.Title, request.Filter.YearOfRelease, request.Filter.Genres, It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Handle_Returns_Retrieved_Movies()
        {
            var movies = BuilderCollection.Generate<Movie>().ToList();

            _mockMovies
                .Setup(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(movies);

            var response = await Sut.Handle(new SearchMoviesQueryBuilder().Build(), default);

            Assert.AreEqual(movies, response.Movies);
        }
    }
}
