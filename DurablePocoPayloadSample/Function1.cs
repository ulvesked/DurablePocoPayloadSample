using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace DurablePocoPayloadSample
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req, [DurableClient] DurableClientContext durableClient)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var instanceID = await durableClient.Client.ScheduleNewOrchestrationInstanceAsync(nameof(Orchestrator));

            var response = durableClient.CreateCheckStatusResponse(req, instanceID);

            return response;
        }
    }
}
