# Frends.Community.AWS.SQS

FRENDS Community Task for SQS

 [![Actions Status](https://github.com/CommunityHiQ/Frends.Community.AWS.SQS/workflows/PackAndPushAfterMerge/badge.svg)](https://github.com/CommunityHiQ/Frends.Community.AWS.SQS/actions) ![MyGet](https://img.shields.io/myget/frends-community/v/Frends.Community.AWS.SQS) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) 

- [Installing](#installing)
- [Tasks](#tasks)
     - [GetBasicAWSCredentials](#GetBasicAWSCredentials)
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
| value | `object` | See https://docs.aws.amazon.com/sdkfornet1/latest/apidocs/html/T_Amazon_Runtime_BasicAWSCredentials.htm |  |

Use return value later for task inputs.

`#result`


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
| AWSCredentials | `AWSCredentials` | AWSCredentials class instance. See https://docs.aws.amazon.com/sdkfornet1/latest/apidocs/html/T_Amazon_Runtime_AWSCredentials.htm. Can be null (see UseDefaultCredentials)  | `#result[GetBasicAWSCredentials]` |

### Returns

A SendMessageResponse object instance

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| value | `object` | See https://docs.aws.amazon.com/sdkfornet/v3/apidocs/items/SQS/TSendMessageResponse.html |  |

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
| 1.0.0   | First .NET Standard version |
