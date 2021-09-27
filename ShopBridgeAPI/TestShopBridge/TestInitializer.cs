using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopBridgeAPI;
using ShopBridgeAPI.Helper;
using ShopBridgeAPI.Model;
using System.Net.Http;


namespace TestShopBridge
{
    [TestClass]
    public class TestInitializer
    {
       


        public static HttpClient TestHttpClient;
        public static Mock<ShopBridgeHelper> MockShopBridgeRepository;

        [AssemblyInitialize]
        public static void InitializeTestServer(TestContext testContext)
        { 

            var testServer = new TestServer(new WebHostBuilder()
               .UseStartup<TestStartup>());
               // this would cause it to use StartupIntegrationTest class
               // or ConfigureServicesIntegrationTest / ConfigureIntegrationTest
               // methods (if existing)
               // rather than Startup, ConfigureServices and Configure
               //.UseEnvironment("ConfigureServicesIntegrationTest"));

            TestHttpClient = testServer.CreateClient();
        }

        public static void RegisterMockRepositories(IServiceCollection services)
        {
            MockShopBridgeRepository = (new Mock<ShopBridgeHelper>());
            services.AddSingleton(MockShopBridgeRepository.Object);

            //add more mock repositories below
        }
    }
}
