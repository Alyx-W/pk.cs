using System;
using Models;
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
            if (member.AvatarUrl != null) { 
                Console.WriteLine(member.AvatarUrl.ToString());
                Console.ReadLine();
            } else { 
                Console.WriteLine(member.ID);
                Console.ReadLine();
            }
            Assert.IsType<Member>(member);
        }
    }
}