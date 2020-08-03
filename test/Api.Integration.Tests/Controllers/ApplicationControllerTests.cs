using JestDotnet;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Integration.Tests.Controllers
{
    public class ApplicationControllerTests
    {
        private CustomWebApplicationFactory<Startup> factory;
        private HttpClient client;
        private const string RootRoute = "v1/applications";

        [OneTimeSetUp]
        public void SetUp()
        {
            factory = new CustomWebApplicationFactory<Startup>();
            client = factory.CreateClient();
        }

        [Test]
        public async Task GetAll_Ok()
        {
            var request = TestUtils.CreateGetRequest(RootRoute);
            var response = await TestUtils.SendOkRequest(client, request);

            var entity = await TestUtils.Deserialize(response);
            entity.ShouldMatchSnapshot();
        }

        [Test]
        public async Task Get_Ok()
        {
            var request = TestUtils.CreateGetRequest($"{RootRoute}/App1");
            var response = await TestUtils.SendOkRequest(client, request);

            var entity = await TestUtils.Deserialize(response);
            entity.ShouldMatchSnapshot();
        }
    }
}
