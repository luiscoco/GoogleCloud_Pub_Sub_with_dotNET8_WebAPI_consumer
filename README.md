# GoogleCloud Pub/Sub with dotNET8 WebAPI producer

## 1. Create Google Cloud Pub/Sub service

**Google Cloud Project**: You'll need a Google Cloud Project, if you don't have one, create one at https://console.cloud.google.com

**Pub/Sub API Enabled**: Make sure the Pub/Sub API is enabled in your project. You can check this or enable it in the "APIs & Services" section of the Google Cloud Console

We first have to log in to Google Cloud Service 

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/434e7c37-a5af-46f3-9039-333c7155da53)

We have to search for Pub/Sub service 

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/bbc6178e-f2d5-4323-9fd7-3c84800d5c46)

### 1.1. Create a Topic

We press **CREATE TOPIC** button 

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/1bda8bf5-9b43-453c-97f6-17dc858c1f39)

We input the topic name an press the **CREATE** button

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/f22cf987-2885-45a5-b6f3-050cf24eef42)

We verify the new topic and the corresponding subscription were created

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/5cc67d2c-9b34-44c3-bd32-89f1be2960e8)

### 1.2. Create a Service Account

We first navigate to the IAM and Admin service

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/cb2f7c3e-2378-4d3f-ad10-513231119034)

We select the **Service Account** option in the left hand side menu, then we press the **CREATE SERVICE ACCOUNT** button

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/92c48fbb-a0c5-4be7-8b30-0fd09cf580ed)

We input the Service Account details and we press the **CREATE AND CONTINUE** button

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/2ece5419-39b6-4c3d-ac64-ac47a2631969)

We grant the permission to the service account

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/3e268e56-3422-4d80-ac3d-906d888da607)

Once we granted the permissions we press the **Continue** button

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_consumer/assets/32194879/0211947c-280b-40c2-b5aa-3c415f370311)

We finally press the **Done** button

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/a4be875d-6724-433b-9518-06a8e53145e7)

We verify our new service accoung. We press on the email link 

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/11646265-1ba8-4e4d-b07d-b21b31282e97)

We also create a new Key with a JSON format. For this porpuse we click on the **Keys** tab

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/e21f0579-2f54-4cc0-baa9-da3dcfd1ed6b)

Then we press **Create new key** option and we select the JSON option in the subsequent dialog box

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/7cbe59c0-c5cf-482a-9c4f-f7d1ff8a19c6)

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/3b3bd2ff-b6ff-49de-a263-984e453c5b97)

We can see in the download folder the JSON credentials file downloaded from Google Cloud Service Account

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/217299e5-5003-4b9d-9b60-01093b4f37c7)

### 1.3. Set Environment Variable

We run the application to edit the environmental variables 

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/ab8ad61b-f6e2-435b-808b-fc32443eca60)

We have to create a new environmental variable called **GOOGLE_APPLICATION_CREDENTIALS**

This variable have to point to the path where we have placed the JSON key file for our Google Cloud Service Account

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/62da6348-303c-4c04-bae1-c18223b56072)

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer/assets/32194879/3e3028da-ae48-41b1-a5fa-35de3fcd8b54)

## 2. Create a .NET8 WebAPI with VSCode

Creating a .NET 8 Web API using Visual Studio Code (VSCode) and the .NET CLI is a straightforward process

This guide assumes you have .NET 8 SDK, VSCode, and the C# extension for VSCode installed. If not, you'll need to install these first

**Step 1**: Install .NET 8 SDK

Ensure you have the .NET 8 SDK installed on your machine: https://dotnet.microsoft.com/es-es/download/dotnet/8.0

You can check your installed .NET versions by opening a terminal and running:

```
dotnet --list-sdks
```

If you don't have .NET 8 SDK installed, download and install it from the official .NET download page

**Step 2**: Create a New Web API Project

Open a terminal or command prompt

Navigate to the directory where you want to create your new project

Run the following command to create a new Web API project:

```
dotnet new webapi -n GooglePubSubReceiverApi
```

This command creates a new directory with the project name, sets up a basic Web API project structure, and restores any necessary packages

**Step 3**: Open the Project in VSCode

Once the project is created, you can open it in VSCode by navigating into the project directory and running:

```
code .
```

This command opens VSCode in the current directory, where . represents the current directory

## 3. Load project dependencies

We run this command to load the project library

```
dotnet add package Google.Cloud.PubSub.V1
```

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_consumer/assets/32194879/8f4d95fd-2edc-4ace-9909-e1a6b9c634cd)

## 4. Create the project structure

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_consumer/assets/32194879/aa4117aa-ab04-4bc9-9d83-2251ea0d4712)

## 5. Create the Controller

**PubSubReceiverApiController.cs**

```csharp
using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubSubReceiverApi.Controllers
{
    public class MessageDto
    {
        public string? Body { get; set; }
        public string? Priority { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class PubSubController : ControllerBase
    {
        private static string projectId = "endless-set-412215";
        private static string subscriptionId = "mytopic-sub";
        private static SubscriberClient? subscriber;
        private static ConcurrentQueue<MessageDto> receivedMessages = new ConcurrentQueue<MessageDto>();

        [HttpGet("receive")]
        public ActionResult<IEnumerable<MessageDto>> ReceiveMessages(string? priority = null)
        {
            if (string.IsNullOrEmpty(priority))
            {
                return receivedMessages.ToList();
            }
            else
            {
                return receivedMessages.Where(m => m.Priority == priority).ToList();
            }
        }

        // Ensure this method is defined and matches what is called in Program.cs
        public static async Task StartMessageProcessing(CancellationToken stoppingToken)
        {
            SubscriptionName subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);
            subscriber = await SubscriberClient.CreateAsync(subscriptionName);
            await subscriber.StartAsync((message, cancellationToken) =>
            {
                // Message handling logic
                string body = message.Data.ToStringUtf8();
                message.Attributes.TryGetValue("priority", out string priority);
                Console.WriteLine($"Received message: {body}, Priority: {priority}");

                receivedMessages.Enqueue(new MessageDto { Body = body, Priority = priority ?? "normal" });

                return Task.FromResult(SubscriberClient.Reply.Ack);
            });
        }
    }
}
```

## 6. Modify the application middleware(program.cs)

**Program.cs**

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PubSubReceiverApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<PubSubBackgroundService>();

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PubSubReceiverApi", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PubSubReceiverApi v1");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
```

## 7. Create a BackgroundService

**PubSubBackgroundService**

```csharp
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using PubSubReceiverApi.Controllers;
public class PubSubBackgroundService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Assuming PubSubController has been adjusted to support this pattern
        await PubSubController.StartMessageProcessing(stoppingToken);
    }
}
```

## 8. Run and Test the application

We execute the following command to run the application

```
dotnet run
```

We first run the **producer** application and we send a message to the Google Cloud Pub/Sub Topic

https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_producer

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_consumer/assets/32194879/ad3a6d6f-e559-4cbc-b56b-0a9c71ab3e9c)

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_consumer/assets/32194879/2c700b68-2276-4f1a-955a-8f07537d9b29)

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_consumer/assets/32194879/2cbb874b-09a9-4732-80e0-d5accec91e24)

Then we run the **receiver** application and we receive the message from the Google Cloud Pub/Sub Subscription

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_consumer/assets/32194879/fd387d4b-7f25-4a24-9453-82859c318969)

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_consumer/assets/32194879/d15a17bc-5c7f-428a-b948-7189ea3aae5c)

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_consumer/assets/32194879/ada5e816-ce9d-46a7-adc6-ce370af34deb)

We also verify in the Google Cloud the message received. First we have to stop the Receiver application, because the background service is continously pulling the messages

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_consumer/assets/32194879/3a3a26d5-510b-4b42-a50a-1f9a6acc437d)

![image](https://github.com/luiscoco/GoogleCloud_Pub_Sub_with_dotNET8_WebAPI_consumer/assets/32194879/7f84bb05-9265-428d-92b3-34a156df7388)



