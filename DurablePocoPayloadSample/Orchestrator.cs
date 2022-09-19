using Microsoft.DurableTask;

namespace DurablePocoPayloadSample
{
    [DurableTask(nameof(Orchestrator))]
    public class Orchestrator : TaskOrchestratorBase<object, int>
    {
        protected override async Task<int> OnRunAsync(TaskOrchestrationContext context, object input)
        {
            var payload = await context.CallPrepareDataActivityAsync("Test");
            var result = await context.CallPayloadSerializationActivityAsync(payload);
            Console.WriteLine("OK");
            return result;
        }
    }
}
