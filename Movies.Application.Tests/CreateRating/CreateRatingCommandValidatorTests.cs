using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Application.CreateRating;
using Movies.Application.Tests.Internal;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Application.Tests.CreateRating
{
    [TestClass]
    public class CreateRatingCommandValidatorTests
    {
        private readonly CreateRatingCommandValidator Sut = new CreateRatingCommandValidator();

        [TestMethod]
        public async Task ValidateAsync_Returns_0_Errors_When_Command_Is_Valid()
        {
            var result = await Sut.ValidateAsync(new CreateRatingCommandBuilder().Build());

            Assert.IsTrue(result.IsValid);
            Assert.IsFalse(result.Errors.Any());
        }

        [TestMethod]
        public async Task ValidateAsync_Returns_1_Error_When_UserID_Is_0()
        {
            var result = await Sut.ValidateAsync(new CreateRatingCommandBuilder().WithUserID(0).Build());

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any());

            var error = result.Errors.First();

            Assert.AreEqual("UserID", error.PropertyName);
        }

        [TestMethod]
        public async Task ValidateAsync_Returns_1_Error_When_MovieID_Is_0()
        {
            var result = await Sut.ValidateAsync(new CreateRatingCommandBuilder().WithMovieID(0).Build());

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any());

            var error = result.Errors.First();

            Assert.AreEqual("MovieID", error.PropertyName);
        }

        [TestMethod]
        public async Task ValidateAsync_Returns_1_Error_When_Rating_Is_0()
        {
            var result = await Sut.ValidateAsync(new CreateRatingCommandBuilder().WithRating(0).Build());

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any());

            var error = result.Errors.First();

            Assert.AreEqual("Rating", error.PropertyName);
        }

        [TestMethod]
        public async Task ValidateAsync_Returns_1_Error_When_Rating_Is_Greater_Than_5()
        {
            var result = await Sut.ValidateAsync(new CreateRatingCommandBuilder().WithRating(ObjectMother.Create<int>(Context.WithMinValue(5))).Build());

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any());

            var error = result.Errors.First();

            Assert.AreEqual("Rating", error.PropertyName);
        }
    }
}
