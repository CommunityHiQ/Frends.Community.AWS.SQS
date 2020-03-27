using Amazon.Runtime;
using Amazon.SQS.Model;
using NUnit.Framework;
using System;

namespace Frends.Community.AWS.SQS.Tests
{
    [TestFixture]
    class TestClass
    {
        private string accessKey;
        private string secretKey;
        private string queueURL;
        private Regions region;

        [SetUp]
        public void Init()
        {
            accessKey = GetConfigValue("AWS.SQS.aws_access_key_id");
            secretKey = GetConfigValue("AWS.SQS.aws_secret_access_key");
            queueURL = GetConfigValue("AWS.SQS.aws_sqs_queue");
            region = (Regions)int.Parse(GetConfigValue("AWS.SQS.aws_sqs_region"));
        }

        /// <summary>
        /// Send a message to the FIFO queue
        /// </summary>
        [Test]
        public void SendMessage()
        {

            var input = new Parameters
            {
                QueueUrl = queueURL,
                Message = $@"Frends.Community.AWS.SQS.Tests.SendMessage() test. 
Datetime: {DateTime.Now.ToString("o")}
"
            };

            var options = new SendOptions
            {
                DelaySeconds = 0,
                MessageDeduplicationId = queueURL.Contains(".fifo") ?  Guid.NewGuid().ToString() : "", // FIFO, ContentBasedDeduplication disabled
                MessageGroupId = queueURL.Contains(".fifo") ? "1" : ""            // FIFO
            };

            var awsOptions = new AWSOptions
            {
                AWSCredentials = SQS.GetBasicAWSCredentials(accessKey, secretKey),
                UseDefaultCredentials = false,
                Region = region
            };

            var ret = SQS.SendMessage(input, options, awsOptions, new System.Threading.CancellationToken());

            Assert.IsTrue(((SendMessageResponse)ret.Result).HttpStatusCode == System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Get env value
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Value</returns>
        private string GetConfigValue(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }
    }
}
