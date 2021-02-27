using SessionDemo.Test.MockResources;
using IMDBAppAPI;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
using IMDBAppAPI.Services;

namespace SessionDemo.Test.StepFiles
{
    [Scope(Feature = "Actor Resource")]
    [Binding]
    public class ActorSteps : BaseSteps
    {
        public ActorSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(service => ActorMock.ActorRepoMock.Object);
                    services.AddScoped<IActorService, ActorService>();
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            ActorMock.MockGetAll();
            ActorMock.MockGet();
            ActorMock.MockAdd();
            ActorMock.MockDelete();
            ActorMock.MockUpdate();
            ActorMock.MockGetByMovieId();
        }
    }
}