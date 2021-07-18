using System;
using Models;
using Xunit;
using library;
using PluralkitAPI.Client;
using PluralkitAPI.Models;

namespace library.testing
{
    public class Test
    {
        [Fact]
        public void TestingGetMember()
        {
            PKClient client = new PKClient();
            var member = client.GetMember("cewel");
            Console.WriteLine(member);
            Assert.IsType<Member>(member);
        }
        /*
        [Fact]
        public void TestingSetMember() 
        { 
            var client = new PKClient("");
            var member = client.EditMember("cewel");

            Assert.IsType<Member>(member);
        } */
    }
}