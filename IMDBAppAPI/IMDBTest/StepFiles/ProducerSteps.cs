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

    [Scope(Feature = "Producer Resource")]
    [Binding]
    public class ProducerSteps : BaseSteps
    {
        public ProducerSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(service => ProducerMock.ProducerRepoMock.Object);
                    services.AddScoped<IProducerService, ProducerService>();
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            ProducerMock.MockGetAll();
            ProducerMock.MockGet();
            ProducerMock.MockAdd();
            ProducerMock.MockDelete();
            ProducerMock.MockUpdate();
            ProducerMock.MockGetByMovieId();
        }
    }
}
