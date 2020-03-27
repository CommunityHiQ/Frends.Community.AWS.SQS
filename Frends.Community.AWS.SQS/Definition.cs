#pragma warning disable 1591

using Amazon;
using Amazon.Runtime;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.Community.AWS.SQS
{
    /// <summary>
    /// Message parameters
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Queue url.
        /// Examples: https://{REGION_ENDPOINT}/queue.|api-domain|/{YOUR_ACCOUNT_NUMBER}/{YOUR_QUEUE_NAME}
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue("https://{REGION_ENDPOINT}/queue.|api-domain|/{YOUR_ACCOUNT_NUMBER}/{YOUR_QUEUE_NAME}")]
        public string QueueUrl { get; set; }

        /// <summary>
        ///  Message to be sent. Maximum size is 256kb
        ///  Examples: foo;12345
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue("Hello")]
        public string Message { get; set; }
    }

    /// <summary>
    /// Message options
    /// </summary>
    [DisplayName("Options")]
    public class SendOptions
    {
        /// <summary>
        /// The tag that specifies that a message belongs to a specific message group. (FIFO)
        /// </summary>
        [DisplayName("MessageGroupId")]
        [DefaultValue("")]
        public string MessageGroupId { get; set; }

        /// <summary>
        /// MessageDeduplicationId (FIFO)
        /// </summary>
        [DisplayName("MessageDeduplicationId")]
        [DefaultValue("")]
        public string MessageDeduplicationId { get; set; }

        /// <summary>
        /// The number of seconds to delay the message from being available for processing. 
        /// </summary>
        [DefaultValue(0)]
        public int DelaySeconds { get; set; }
    }

    /// <summary>
    /// AWS Options
    /// </summary>
    public class AWSOptions
    {
        /// <summary>
        /// Region selection, default EUNorth1. Undefined doesn't select region.
        /// </summary>
        [DisplayName("Region")]
        public Regions Region { get; set; }

        /// <summary>
        /// Credentials are loaded from the application's default configuration, and if unsuccessful from the Instance Profile service on an EC2 instance. 
        /// </summary>
        public bool UseDefaultCredentials { get; set; }

        /// <summary>
        /// AWSCredentials class instance. See https://docs.aws.amazon.com/sdkfornet1/latest/apidocs/html/T_Amazon_Runtime_AWSCredentials.htm
        /// </summary>
        [DisplayFormat(DataFormatString = "Expression")]
        [PasswordPropertyText]
        public object AWSCredentials { get; set; }
    }

    #region Enumerations

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public enum Regions
    {
        EUNorth1,
        EuWest1,
        EuWest2,
        EUWest3,
        EuCentral1,
        ApNortheast1,
        ApNortheast2,
        ApSouth1,
        ApSoutheast1,
        ApSoutheast2,
        CaCentral1,
        CnNorth1,
        CNNorthWest1,
        SaEast1,
        UsEast1,
        UsEast2,
        UsWest1,
        UsWest2,
        Undefined
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    
    #endregion
}

