using Amazon.Runtime;
using Amazon.SQS.Model;
using NUnit.Framework;
using System;

namespace Frends.Community.AWS.SQS.Tests
{
    [TestFixture]
    class TestClass
    {
        [Test]
        public void SendMessage()
        {
            var accessKey = GetConfigValue("aws_access_key_id");
            var secretKey = GetConfigValue("aws_secret_access_key");
            var queueURL = GetConfigValue("aws_sqs_queue");
            var region = (Regions) int.Parse(GetConfigValue("aws_sqs_region"));

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

        private string GetConfigValue(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }
    }
}
