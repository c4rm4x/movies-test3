using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movies.Application.CreateRating;
using Movies.Application.Tests.Internal;
using Movies.Domain.Entities;
using Movies.Domain.Repositories;
using Movies.Domain.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Tests.CreateRating
{
    [TestClass]
    public class CreateRatingCommandHandlerTests
    {
        private Mock<IMovieRepository> _mockMovies;
        private Mock<IUserRepository> _mockUsers;
        private Mock<IMovieRatingService> _mockMovieRatingService;
        private CreateRatingCommandHandler Sut;

        [TestInitialize]
        public void Setup()
        {
            _mockMovies = new Mock<IMovieRepository>();
            _mockUsers = new Mock<IUserRepository>();
            _mockMovieRatingService = new Mock<IMovieRatingService>();

            Sut = new CreateRatingCommandHandler(
                _mockMovies.Object,
                _mockUsers.Object,
                _mockMovieRatingService.Object);

            _mockMovies
                .Setup(m => m.GetByIDAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(ObjectMother.Create<Movie>());

            _mockUsers
                .Setup(m => m.GetByIDAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(ObjectMother.Create<User>());
        }

        [TestMethod]
        public async Task Handle_Should_Retrieve_Given_Request_MovieID()
        {
            var request = new CreateRatingCommandBuilder().Build();

            await Sut.Handle(request, default);

            _mockMovies.Verify(m => m.GetByIDAsync(request.MovieID, It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Handle_Should_Return_ResourceNotFoundResponse_When_No_Movie_Is_Found()
        {
            _mockMovies
                .Setup(m => m.GetByIDAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(default(Movie));

            var request = new CreateRatingCommandBuilder().Build();

            var response = await Sut.Handle(request, default);

            Assert.IsInstanceOfType(response, typeof(ResourceNotFoundResponse));

            var resourceNotFoundResponse = response as ResourceNotFoundResponse;

            Assert.AreEqual($"No movie with id {request.MovieID} has been found", resourceNotFoundResponse.Message);
        }

        [TestMethod]
        public async Task Handle_Should_Retrieve_Given_Request_UserID()
        {
            var request = new CreateRatingCommandBuilder().Build();

            await Sut.Handle(request, default);

            _mockUsers.Verify(m => m.GetByIDAsync(request.UserID, It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Handle_Should_Return_ResourceNotFoundResponse_When_No_User_Is_Found()
        {
            _mockUsers
                .Setup(m => m.GetByIDAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(default(User));

            var request = new CreateRatingCommandBuilder().Build();

            var response = await Sut.Handle(request, default);

            Assert.IsInstanceOfType(response, typeof(ResourceNotFoundResponse));

            var resourceNotFoundResponse = response as ResourceNotFoundResponse;

            Assert.AreEqual($"No user with id {request.UserID} has been found", resourceNotFoundResponse.Message);
        }

        [TestMethod]
        public async Task Handle_Should_Add_Or_Update_New_Rating()
        {
            var movie = ObjectMother.Create<Movie>();

            _mockMovies
               .Setup(m => m.GetByIDAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(movie);

            var user = ObjectMother.Create<User>();

            _mockUsers
                .Setup(m => m.GetByIDAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            var request = new CreateRatingCommandBuilder().Build();

            await Sut.Handle(request, default);

            _mockMovieRatingService.Verify(m => m.AddOrUpdateAsync(movie, user, request.Rating, It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Handle_Should_Return_CreateRatingCommandResponse_When_Success()
        {
            var response = await Sut.Handle(new CreateRatingCommandBuilder().Build(), default);

            Assert.IsInstanceOfType(response, typeof(CreateRatingCommandResponse));
        }
    }
}
