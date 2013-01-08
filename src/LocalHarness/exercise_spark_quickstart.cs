using System.Diagnostics;
using FubuMVC.QuickStart.Spark;
using NUnit.Framework;
using FubuMVC.Katana;
using FubuTestingSupport;

namespace LocalHarness
{
    [TestFixture]
    public class exercise_spark_quickstart
    {
        [Test]
        public void hit_the_home_page()
        {
            using (var server = EmbeddedFubuMvcServer.For<MyApplication>())
            {
                server.Endpoints.Get<HomeEndpoint>(x => x.Index()).ReadAsText()
                      .ShouldEqual("Hello, you've just built your first FubuMVC application");
            }
        }
    }
}