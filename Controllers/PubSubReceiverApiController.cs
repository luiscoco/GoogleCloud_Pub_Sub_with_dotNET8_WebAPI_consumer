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
