using System;
using Xunit;
using library;
using PluralkitCore;

namespace library.testing
{
    public class Test
    {
        [Fact]
        public void TestingGetMember()
        {
            var client = new PKClient();
            var member = client.GetMember("cewel");
            Assert.NotNull(member);
        }
    }
}