using Microsoft.DurableTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurablePocoPayloadSample
{
    [DurableTask(nameof(PrepareDataActivity))]
    public class PrepareDataActivity : TaskActivityBase<string, TestPayload>
    {
        protected override Task<TestPayload?> OnRunAsync(TaskActivityContext context, string? input)
        {
            var rnd = new Random();
            var img1 = new byte[1024];
            var img2 = new byte[1024];
            var thmb1 = new byte[1024];
            var thmb2 = new byte[1024];
            rnd.NextBytes(img1);
            rnd.NextBytes(img2);
            rnd.NextBytes(thmb1);
            rnd.NextBytes(thmb2);
            return Task.FromResult(new TestPayload
            {
                Name = input,
                Items = new List<TestPayloadItem>
                {
                    new TestPayloadItem
                    {
                        Id = Guid.NewGuid(),
                        Image = img1,
                        Thumbnail = thmb1,
                    },
                    new TestPayloadItem
                    {
                        Id = Guid.NewGuid(),
                        Image = img2,
                        Thumbnail = thmb2,
                    }
                }
            });
 
        }

    }
}
