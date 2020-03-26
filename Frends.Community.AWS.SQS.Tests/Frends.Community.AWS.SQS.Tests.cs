using NUnit.Framework;

namespace Frends.Community.AWS.SQS.Tests
{
    [TestFixture]
    class TestClass
    {
        [Test]
        public void ThreeSQSs()
        {
            var input = new Parameters
            {
                Message = "foobar",
            };

            var options = new Options
            {
                Amount = 3,
                Delimiter = ", "
            };

            var ret = SQS.SendMessage(input, options, new System.Threading.CancellationToken());

            Assert.That(ret.Replication, Is.EqualTo("foobar, foobar, foobar"));
        }
    }
}
