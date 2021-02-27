
using IMDBAppAPI.Services;
using SessionDemo.Test;
using SessionDemo.Test.StepFiles;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
using IMDB.Test.MockResources;
using IMDBAppAPI;

namespace IMDB.Test.StepFiles
{

    [Scope(Feature = "Genre Resource")]
    [Binding]
    public class GenreSteps : BaseSteps
    {
        public GenreSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(service => GenreMock.GenreRepoMock.Object);
                    services.AddScoped<IGenreService, GenreService>();
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            GenreMock.MockGetAll();
            GenreMock.MockGet();
            GenreMock.MockAdd();
            GenreMock.MockDelete();
            GenreMock.MockUpdate();
            GenreMock.MockGetByMovieId();
        }
    }
}
