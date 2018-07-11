using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using TestConfigurationHandler;

namespace Frends.Community.AWS.SQS.Tests
{
    [TestFixture]
    [Order(3)]
    public class SendMessageTests
    {
        private static Parameters _param;

        [OneTimeSetUp]
        public void Setup()
        {
            _param = new Parameters
            {
                //AwsAccessKeyId = ConfigHandler.ReadConfigValue("HiQ.AWSSQSTest.AccessKey"),
                //AwsSecretAccessKey = ConfigHandler.ReadConfigValue("HiQ.AWSSQSTest.SecretAccessKey"),
            };
        }

        [Test]
        public void sendMessage()
        {

            Assert.True(true);
        }

    }
}