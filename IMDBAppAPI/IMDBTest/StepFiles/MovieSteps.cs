using SessionDemo.Test.MockResources;
using IMDBAppAPI;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
using IMDBAppAPI.Services;
using SessionDemo.Test.StepFiles;
using SessionDemo.Test;
using IMDB.Test.MockResources;

namespace IMDB.Test.StepFiles
{
    [Scope(Feature = "Movie Resource")]
    [Binding]
    public class MovieSteps : BaseSteps
    {
        public MovieSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(services => ActorMock.ActorRepoMock.Object);
                    services.AddScoped(service => ProducerMock.ProducerRepoMock.Object);
                    services.AddScoped(services => GenreMock.GenreRepoMock.Object);
                    services.AddScoped(service => MovieMock.MovieRepoMock.Object);
                    services.AddScoped<IActorService, ActorService>();
                    services.AddScoped<IProducerService, ProducerService>();
                    services.AddScoped<IGenreService, GenreService>();
                    services.AddScoped<IMovieService, MovieService>();
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            MovieMock.MockGetAll();
            MovieMock.MockGet();
            MovieMock.MockAdd();
            MovieMock.MockDelete();
            MovieMock.MockUpdate();
            ActorMock.MockGetByMovieId();
            GenreMock.MockGetByMovieId();
            ProducerMock.MockGetByMovieId();

        }
    }
}
