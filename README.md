# Frends.Community.AWS.SQS
Frends tasks to handle AWS SQS operations. For example, send message into queue.
***
- [Installing](#installing)
- [Tasks](#tasks)
  - [SendMessage](#sendmessage)
    - [SendMessage Input](#sendmessage-input)
    - [SendMessage Parameters](#sendmessage-parameters)
	- [SendMessage Options](#sendmessage-options)
    - [endMessage Result](#sendmessage-result)
- [License](#license)
- [Building from source](#building-from-source)
- [Contributing](#contributing)
- [Changelog](#changelog)

***
## Installing
You can install the task via FRENDS UI Task View or you can find the nuget package from the following nuget feed
'[https://www.myget.org/F/frends/api/v2](https://www.myget.org/F/frends/api/v2)'
***
## Tasks

### SendMessage

#### SendMessage Input
Property | Type | Description | Example (comma separated)
---------|------|-------------|--------
QueueUrl | string | https://{REGION_ENDPOINT}/queue.|api-domain|/{YOUR_ACCOUNT_NUMBER}/{YOUR_QUEUE_NAME} | 
Message | string | Message content | 


#### SendMessage Parameters
Property | Type | Description | Example (comma separated)
---------|------|-------------|--------
AWSAccessKeyID | String (secret) | SQS Access Key, #env-variable use is encouraged. | AKIAIOSFODNN7EXAMPLE
AWSSecretAccessKey | String (secret) | SQS Access Key, #env-variable use is encouraged. | wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY
AwsCredentials | dynamic | Used ONLY for GetTemporaryCredentialsTask result. If set, other keys are ignored. | #result[Get Temporary Credentials]
Region | Selector | Location for SQS, select from dropdown-list. | EUWest1

#### SendMessage Options
Property | Type | Description | Example (comma separated)
---------|------|-------------|--------
MessageGroupID | string | https://docs.aws.amazon.com/AWSSimpleQueueService/latest/APIReference/API_SendMessage.html | 7
MessageDeduplicationID  | string |  https://docs.aws.amazon.com/AWSSimpleQueueService/latest/APIReference/API_SendMessage.html | System.Guid.NewGuid().ToString()

#### SendMessage Result
Property | Type | Description | Example (comma separated)
---------|------|-------------|--------
Result | dynamic SendMessageResponse | https://docs.aws.amazon.com/sdkfornet/latest/apidocs/items/TSQSSendMessageResponseNET45.html | 
***

## License
MIT License.
***
## Building from source

Clone a copy of the repo

`git clone https://github.com/CommunityHiQ/Frends.Community.AWS.SQS.git`

Restore dependencies

`nuget restore frends.community.aws.sqs`

Rebuild the project

Run Tests with nunit3. Tests can be found under

`Frends.Community.AWS.Tests\bin\Release\Frends.Community.AWS.SQS.Tests.dll`

Create a nuget package

`nuget pack nuspec/Frends.Community.AWS.SQS.nuspec`

# Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repo on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

# Changelog

| Version             | Changes              |
| --------------------| ---------------------|
| pre 0.0.15 | first commit  |