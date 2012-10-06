using FubuTestingSupport;
using NUnit.Framework;

namespace FubuRelease.Testing
{
    [TestFixture]
    public class StandinTester
    {
        [Test]
        public void it_is_all_good()
        {
            1.ShouldEqual(1);
        }
    }
}