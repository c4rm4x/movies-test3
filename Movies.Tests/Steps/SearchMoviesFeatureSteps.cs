using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Movies.Tests.Steps
{
    [Binding]
    public class SearchMoviesFeatureSteps
    {
        private readonly ScenarioContext _context;

        private static TestServer _server;

        [BeforeFeature]
        public static void Setup()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>());
        }

        [AfterFeature]
        public static void Cleanup()
        {
            _server?.Dispose();
        }

        public SearchMoviesFeatureSteps(ScenarioContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [Given(@"No search criteria is given")]
        public void GivenNoSearchCriteriaIsGiven()
        {
            _context.Add("criteria", null);
        }

        [Given(@"Search by title '(.*)'")]
        public void GivenSearchByTitle(string title)
        {
            _context.Add("criteria", new Dictionary<string, string>
            {
                { "title", title }
            });
        }

        [When(@"searching")]
        public async Task WhenSearching()
        {
            var criteria = _context["criteria"] as IDictionary<string, string>;

            var queryString = criteria == null
                ? string.Empty
                : string.Join('&', criteria.Select(kv => $"{kv.Key}={kv.Value}"));

            var client = _server.CreateClient();

            var response = await client.GetAsync($"api/movies/search?{queryString}");

            _context.Add("searchResponse", response);
        }

        [Then(@"the result should be bad request")]
        public void ThenTheResultShouldBeBadRequest()
        {
            var response = _context["searchResponse"] as HttpResponseMessage;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Then(@"the result should be successful")]
        public async Task ThenTheResultShouldBeSuccessful()
        {
            var response = _context["searchResponse"] as HttpResponseMessage;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();

            var movies = JsonConvert.DeserializeObject<MovieDto[]>(content);

            Assert.IsTrue(movies.Any());
        }
    }
}
