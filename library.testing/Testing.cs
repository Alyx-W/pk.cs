using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;
using PluralkitAPI.Environment;
using PluralkitAPI.Client;


namespace library.testing
{
    public class Test
    {     
        private string token { get; set; }

        public Test() { 
            var root = Directory.GetCurrentDirectory();
            var dotenv = Path.Combine(root, ".env");
            DotEnv.Load(dotenv);
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