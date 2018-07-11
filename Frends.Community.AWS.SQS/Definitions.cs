using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.Community.AWS.SQS
{
    #region DownloadTask

    /// <summary>
    ///     Input class, you can send message into SQS queue.
    /// </summary>
    [DisplayName("Input")]
    public class SendInput
    {
        /// <summary>
        ///     Queue url.
        ///     Examples: https://{REGION_ENDPOINT}/queue.|api-domain|/{YOUR_ACCOUNT_NUMBER}/{YOUR_QUEUE_NAME}
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue("https://{REGION_ENDPOINT}/queue.|api-domain|/{YOUR_ACCOUNT_NUMBER}/{YOUR_QUEUE_NAME}")]
        public string QueueUrl { get; set; }

        /// <summary>
        ///     Message to be sent.
        ///     Examples: foo;12345
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Message { get; set; }
    }

    /// <summary>
    /// Options
    /// </summary>
    [DisplayName("Options")]
    public class SendOptions
    {
        /// <summary>
        ///     MessageGroupId
        /// </summary>
        [DisplayName("MessageGroupId")]
        public string MessageGroupId { get; set; }

        /// <summary>
        ///     MessageDeduplicationId
        /// </summary>
        [DisplayName("MessageDeduplicationId")]
        public string MessageDeduplicationId { get; set; }

    }

    #endregion

    #region Parameters for all!

    /// <summary>
    ///     Parameter class with username and keys.
    /// </summary>
    public class Parameters
    {
        /// <summary>
        ///     Key name for Amazon SQS transfer aws_access_key_id
        ///     Use #env.variable.
        /// </summary>
        [PasswordPropertyText(true)]
        [DisplayName("AWS Access Key ID")]
        public string AwsAccessKeyId { get; set; }

        /// <summary>
        ///     Secret  key name for Amazon SQS transfer aws_secret_access_key
        ///     Use #env.variable.
        /// </summary>
        [PasswordPropertyText(true)]
        [DisplayName("AWS Secret Access Key")]
        public string AwsSecretAccessKey { get; set; }

        /// <summary>
        ///     Usage: The result of GetTemporaryCredentials-task.
        /// </summary>
        [DisplayName("Temporary Credentials")]
        public dynamic AwsCredentials { get; set; }

        /// <summary>
        ///     Region selection, default EUWest1.
        /// </summary>
        [DisplayName("Region")]
        public Regions Region { get; set; }
    }

    #endregion

    #region Enumerations

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public enum Regions
    {
        EuWest1,
        EuWest2,
        EuCentral1,
        ApNortheast1,
        ApNortheast2,
        ApSouth1,
        ApSoutheast1,
        ApSoutheast2,
        CaCentral1,
        CnNorth1,
        SaEast1,
        UsEast1,
        UsEast2,
        UsWest1,
        UsWest2
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    #endregion
}