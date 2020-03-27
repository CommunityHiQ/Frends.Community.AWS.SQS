using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;


#pragma warning disable 1591

namespace Frends.Community.AWS.SQS
{
    public static class SQS
    {
        static private AmazonSQSClient GetAmazonSQSClient(bool useDefaultCredentials, AWSCredentials awsCredentials, Regions region)
        {
            // App.config or EC2 instance credentials?
            if( useDefaultCredentials == true )
            {
                if( region == Regions.Undefined)
                {
                    return new AmazonSQSClient();
                } else
                {
                    return new AmazonSQSClient(RegionSelection(region));
                }
            } else
            {
                if (region == Regions.Undefined)
                {
                    return new AmazonSQSClient(awsCredentials);
                }
                else
                {
                    return new AmazonSQSClient(awsCredentials, RegionSelection(region));
                }
            }
        }

        /// <summary>
        /// This is task
        /// Documentation: https://github.com/CommunityHiQ/Frends.Community.AWS.SQS
        /// </summary>
        /// <param name="input">Message data</param>
        /// <param name="options">Message options</param>
        /// <param name="awsOptions">AWS options</param>
        /// <param name="cancellationToken"></param>
        /// <returns>{string Replication} </returns>
        public static async Task<object> SendMessage([PropertyTab]Parameters input, [PropertyTab]SendOptions options, [PropertyTab] AWSOptions awsOptions, CancellationToken cancellationToken)
        {
            var sqsClient = GetAmazonSQSClient(awsOptions.UseDefaultCredentials, (AWSCredentials)awsOptions.AWSCredentials, awsOptions.Region);

            var request = new SendMessageRequest
            {
                //MessageAttributes = new Dictionary<string, MessageAttributeValue>
                //{
                //    {
                //        "CustomAttribute", new MessageAttributeValue
                //        { DataType = "String", StringValue = "Esan testi" }
                //    }
                //},
                MessageBody = input.Message,
                QueueUrl = input.QueueUrl,             
                DelaySeconds = options.DelaySeconds,
            };
            
            // FIFO only
            if( !string.IsNullOrEmpty(options.MessageGroupId))
            {
                request.MessageGroupId = options.MessageGroupId;
            }

            // FIFO only
            if (!string.IsNullOrEmpty(options.MessageDeduplicationId))
            {
                request.MessageDeduplicationId = options.MessageDeduplicationId;
            }

            return await sqsClient.SendMessageAsync(request, cancellationToken);
        }

        /// <summary>
        /// Get basic set of credentials consisting of an AccessKey and SecretKey 
        /// </summary>
        /// <param name="accessKey">Access key</param>
        /// <param name="secretKey">Secret key</param>
        /// <returns></returns>
        public static object GetBasicAWSCredentials(string accessKey, [PasswordPropertyText] string secretKey)
        {
            return new BasicAWSCredentials(accessKey, secretKey);
        }

        private static RegionEndpoint RegionSelection(Regions region)
        {
            switch (region)
            {
                case Regions.EUNorth1:
                    return RegionEndpoint.EUNorth1;
                case Regions.EuWest1:
                    return RegionEndpoint.EUWest1;
                case Regions.EuWest2:
                    return RegionEndpoint.EUWest2;
                case Regions.EUWest3:
                    return RegionEndpoint.EUWest3;
                case Regions.EuCentral1:
                    return RegionEndpoint.EUCentral1;
                case Regions.ApSoutheast1:
                    return RegionEndpoint.APSoutheast1;
                case Regions.ApSoutheast2:
                    return RegionEndpoint.APSoutheast2;
                case Regions.ApNortheast1:
                    return RegionEndpoint.APNortheast1;
                case Regions.ApNortheast2:
                    return RegionEndpoint.APNortheast2;
                case Regions.ApSouth1:
                    return RegionEndpoint.APSouth1;
                case Regions.CaCentral1:
                    return RegionEndpoint.CACentral1;
                case Regions.CnNorth1:
                    return RegionEndpoint.CNNorth1;
                case Regions.CNNorthWest1:
                    return RegionEndpoint.CNNorthWest1;
                case Regions.SaEast1:
                    return RegionEndpoint.SAEast1;
                case Regions.UsEast1:
                    return RegionEndpoint.USEast1;
                case Regions.UsEast2:
                    return RegionEndpoint.USEast2;
                case Regions.UsWest1:
                    return RegionEndpoint.USWest1;
                case Regions.UsWest2:
                    return RegionEndpoint.USWest2;

                default:
                    return RegionEndpoint.EUNorth1;
            }
        }
    }
}

