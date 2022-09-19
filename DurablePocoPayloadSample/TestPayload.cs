using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurablePocoPayloadSample
{
    public class TestPayload
    {
        public string Name { get; set; }
        public IEnumerable<TestPayloadItem> Items { get; set; }
    }
    public class TestPayloadItem
    {
        public Guid Id { get; set; }
        public byte[] Image { get; set; }
        public byte[] Thumbnail { get; set; }
    }
}
