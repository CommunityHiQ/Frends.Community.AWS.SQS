using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using Amazon.S3.IO;

namespace Frends.Community.AWS.SQS
{
    /// <summary>
    ///     Amazon AWS SQS operations
    /// </summary>
    public class Tasks
    {
        /// <summary>
        ///     Amazon AWS SQS send message task.
        ///     returns: see https://docs.aws.amazon.com/sdkfornet/latest/apidocs/items/TSQSSendMessageResponseNET45.html
        /// </summary>
        /// <param name="input"></param>
        /// <param name="parameters"></param>
        /// /// <param name="option"></param>
        /// <param name="cToken"></param>
        /// <returns>dynamic SendMessageResponse object</returns>
        public static async Task<dynamic> SendMessage(
            [PropertyTab] SendInput input,
            [PropertyTab] Parameters parameters,
            [PropertyTab] SendOptions option,
            CancellationToken cToken
        )
        {
           cToken.ThrowIfCancellationRequested();

            var stsClient = new AmazonSecurityTokenServiceClient();

            input.IsAnyNullOrWhiteSpaceThrow();

            var amazonSQSClient = parameters.AwsCredentials == null ? new AmazonSQSClient(parameters.AwsAccessKeyId,parameters.AwsSecretAccessKey,Utilities.RegionSelection(parameters.Region)) : new AmazonSQSClient(parameters.AwsCredentials);

            SendMessageRequest sendMessageRequest = new SendMessageRequest();

            sendMessageRequest.QueueUrl = input.QueueUrl;
            sendMessageRequest.MessageBody = input.Message;
            sendMessageRequest.MessageGroupId = option.MessageGroupId;
            sendMessageRequest.MessageDeduplicationId = option.MessageDeduplicationId;

            SendMessageResponse sendMessageResponse = await amazonSQSClient.SendMessageAsync(sendMessageRequest,cToken);

            return sendMessageResponse;
        }
    }
}