using System;
using Xunit;
using PluralkitAPI.Client;
using PluralkitAPI.Models;
using System.Collections.Generic;


namespace library.testing
{
    public class Test
    {      
        private string token { get; set; }
        public Test() { 
            System.Environment.SetEnvironmentVariable("token", "hah lol");

            this.token = System.Environment.GetEnvironmentVariable("token");
        }

        [Fact]
        public void TestingGetSystem()
        {
            PKClient client = new PKClient(null);
            var system = client.GetSystem("lmzyh");

            Assert.IsType<PluralkitAPI.Models.System> (system);
        }
        [Fact]
        public void TestingSetSystem()
        {
            PKClient client = new PKClient(this.token);
            var currentSystem = client.GetSystem("lmzyh");
            var system = client.SetSystem(currentSystem);

            Assert.IsType<PluralkitAPI.Models.System> (system);
        }
        // [Fact]
        // public void TestingCreateMember()
        // {
        //     PKClient client = new PKClient(this.token);
        // }

        [Fact]
        public void TestingGetMember()
        {
            PKClient client = new PKClient(null);
            var member = client.GetMember("cewel");

            Assert.IsType<PluralkitAPI.Models.Member>(member);
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