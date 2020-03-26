using Amazon.Runtime;
using Amazon.SQS.Model;
using NUnit.Framework;

namespace Frends.Community.AWS.SQS.Tests
{
    [TestFixture]
    class TestClass
    {
        [Test]
        public void ThreeSQSs()
        {
            var accessKey = "";
            var secretKey = "";

            var input = new Parameters
            {
                Message = "foobar",
            };

            var options = new SendOptions
            {
                DelaySeconds = 0,
                MessageDeduplicationId = "",
                MessageGroupId = ""
            };

            var awsOptions = new AWSOptions
            {
                AWSCredentials = new BasicAWSCredentials(accessKey, secretKey),
                UseDefaultCredentials = false
            };

            var ret = SQS.SendMessage(input, options, awsOptions, new System.Threading.CancellationToken());

            Assert.IsTrue(((SendMessageResponse)ret.Result).HttpStatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
