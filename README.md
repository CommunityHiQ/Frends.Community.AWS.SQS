# Frends.Community.AWS.SQS

FRENDS Community Task for SQS

 [![Actions Status](https://github.com/CommunityHiQ/Frends.Community.AWS.SQS/workflows/PackAndPushAfterMerge/badge.svg)](https://github.com/CommunityHiQ/Frends.Community.AWS.SQS/actions) ![MyGet](https://img.shields.io/myget/frends-community/v/Frends.Community.AWS.SQS) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) 

- [Installing](#installing)
- [Tasks](#tasks)
     - [GetBasicAWSCredentials](#GetBasicAWSCredentials)
     - [ReceiveMessage](#ReceiveMessage)
     - [SendMessage](#SendMessage)
- [Building](#building)
- [Contributing](#contributing)
- [Change Log](#change-log)

# Installing

You can install the task via FRENDS UI Task View or you can find the NuGet package from the following NuGet feed
https://www.myget.org/F/frends-community/api/v3/index.json and in Gallery view in MyGet https://www.myget.org/feed/frends-community/package/nuget/Frends.Community.AWS.SQS

# Tasks

## GetBasicAWSCredentials

Gets a new BasicAWSCredentials object instance.

### Parameters

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| AccessKey  | `string` | AWS Access key | `AKIAIOSFODNN7EXAMPLE` |
| SecretKey | `string` | AWS Secret key | `wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY` |

### Returns

A BasicAWSCredentials object instance

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| value | `dynamic` | See https://docs.aws.amazon.com/sdkfornet1/latest/apidocs/html/T_Amazon_Runtime_BasicAWSCredentials.htm |  |

Use return value later for task inputs.

`#result`


## DeleteMessage

Deletes the specified message from the specified queue.

### Parameters

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| QueueUrl  | `string` | Queue URL | `https://sqs.us-east-2.amazonaws.com/1234567890123/Test1.fifo` |
| ReceiptHandle  | `string` | The receipt handle associated with the message to delete.  | `712c4c5f-982a-40c5-becb-9b7d0539734e` |


### AWSOptions

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| Region | `enum` | Region selection, default EUNorth1. Undefined doesn't select region. | `1` |
| UseDefaultCredentials | `bool` |  Credentials are loaded from the application's default configuration, and if unsuccessful from the Instance Profile service on an EC2 instance.  | false |
| AWSCredentials | `dynamic` | AWSCredentials class instance. See https://docs.aws.amazon.com/sdkfornet1/latest/apidocs/html/T_Amazon_Runtime_AWSCredentials.htm. Can be null (see UseDefaultCredentials)  | `#result[GetBasicAWSCredentials]` |

### Returns

A ReceiveMessageResponse object instance

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| DeleteMessageResponse | `dynamic` | See https://docs.aws.amazon.com/sdkfornet/v3/apidocs/items/SQS/TDeleteMessageResponse.html |  |

Usage:
Convert return value to JToken and use properties:

`JToken.FromObject(#result)`, `#var.varJToken["HttpStatusCode"]`

## ReceiveMessage

Receives message(s) from the AWS SQS queue.

### Parameters

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| QueueUrl  | `string` | Queue URL | `https://sqs.us-east-2.amazonaws.com/1234567890123/Test1.fifo` |
| MaxNumberOfMessages | `int` | The maximum number of messages to return. Amazon SQS never returns more messages than this value (however, fewer messages might be returned). Valid values: 1 to 10.  | `1` |

### Options

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| DeleteMessageAfterReceiving | `bool` | Delete message(s) from queue after receiving it. | `true` |
| VisibilityTimeout | `int` |  The duration (in seconds) that the received messages are hidden from subsequent retrieve requests after being retrieved by a ReceiveMessage request.   | `45678` |
| WaitTimeSeconds | `int` | The duration (in seconds) for which the call waits for a message to arrive in the queue before returning. If a message is available, the call returns sooner than WaitTimeSeconds. If no messages are available and the wait time expires, the call returns successfully with an empty list of messages.  | `0` |


### AWSOptions

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| Region | `enum` | Region selection, default EUNorth1. Undefined doesn't select region. | `1` |
| UseDefaultCredentials | `bool` |  Credentials are loaded from the application's default configuration, and if unsuccessful from the Instance Profile service on an EC2 instance.  | false |
| AWSCredentials | `dynamic` | AWSCredentials class instance. See https://docs.aws.amazon.com/sdkfornet1/latest/apidocs/html/T_Amazon_Runtime_AWSCredentials.htm. Can be null (see UseDefaultCredentials)  | `#result[GetBasicAWSCredentials]` |

### Returns

A ReceiveMessageResponse object instance

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| ReceiveMessageResponse | `dynamic` | See https://docs.aws.amazon.com/sdkfornet/v3/apidocs/items/SQS/TReceiveMessageResponse.html |  |

Usage:
Convert return value to JToken and use properties:

`JToken.FromObject(#result)`, `#var.varJToken["Messages"]`

## SendMessage

Sends a message to the AWS SQS queue.

### Parameters

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| QueueUrl  | `string` | Queue URL | `https://sqs.us-east-2.amazonaws.com/1234567890123/Test1.fifo` |
| Message | `string` | Message content | `Hello world` |

### Options

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| MessageGroupId | `string` | The tag that specifies that a message belongs to a specific message group. (FIFO)  | `123` |
| MessageDeduplicationId | `string` | Deduplication ID. If a message with a particular message deduplication ID is sent successfully, any messages sent with the same message deduplication ID are accepted successfully but aren't delivered during the 5-minute deduplication interval.   | `45678` |
| DelaySeconds | `int` | How many seconds before the message is visible in the queue. The maximum is 15 minutes. | `0` |


### AWSOptions

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| Region | `enum` | Region selection, default EUNorth1. Undefined doesn't select region. | `1` |
| UseDefaultCredentials | `bool` |  Credentials are loaded from the application's default configuration, and if unsuccessful from the Instance Profile service on an EC2 instance.  | false |
| AWSCredentials | `dynamic` | AWSCredentials class instance. See https://docs.aws.amazon.com/sdkfornet1/latest/apidocs/html/T_Amazon_Runtime_AWSCredentials.htm. Can be null (see UseDefaultCredentials)  | `#result[GetBasicAWSCredentials]` |

### Returns

A SendMessageResponse object instance

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| SendMessageResponse | `dynamic` | See https://docs.aws.amazon.com/sdkfornet/v3/apidocs/items/SQS/TSendMessageResponse.html |  |

Usage:
Convert return value to JToken and use properties:

`JToken.FromObject(#result)`, `#var.varJToken["HttpStatusCode"]`


# Building

Clone a copy of the repo

`git clone https://github.com/CommunityHiQ/Frends.Community.AWS.SQS.git`

Rebuild the project

`dotnet build`

Run Tests

`dotnet test`

Create a NuGet package

`dotnet pack --configuration Release`

# Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repo on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

# Change Log

| Version | Changes |
| ------- | ------- |
| 1.0.0   | First multiplatform version | 
