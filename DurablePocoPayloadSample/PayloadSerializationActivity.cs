using Microsoft.DurableTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurablePocoPayloadSample
{
    [DurableTask(nameof(PayloadSerializationActivity))]
    public class PayloadSerializationActivity : TaskActivityBase<TestPayload, int>
    {
        protected override Task<int> OnRunAsync(TaskActivityContext context, TestPayload? input)
        {
            return Task.FromResult(input.Items.Sum(item => item.Image.Length));
        }
    }
}
