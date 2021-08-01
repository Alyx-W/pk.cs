using System;
using System.IO;
using Xunit;
using PluralkitAPI.Environment;
using PluralkitAPI.Client;


namespace library.testing
{
    public class Test
    {
        private string Token { get; set; }

        public Test()
        {
            string root = Directory.GetCurrentDirectory();
            string dotenv = Path.Combine(root, ".env");
            DotEnv.Load(dotenv);
            Token = Environment.GetEnvironmentVariable("token");
        }

        [Fact]
        public void TestingGetSystem()
        {
            PluralkitAPI.Models.System system = new PKClient(null).GetSystem("lmzyh");

            _ = Assert.IsType<PluralkitAPI.Models.System>(system);
        }

        [Fact]
        public void TestingSetSystem()
        {
            PKClient client = new(Token);
            PluralkitAPI.Models.System currentSystem = client.GetSystem("lmzyh");
            PluralkitAPI.Models.System system = client.SetSystem(currentSystem);

            _ = Assert.IsType<PluralkitAPI.Models.System>(system);
        }
        // [Fact]
        // public void TestingCreateMember()
        // {
        //     PKClient client = new PKClient(this.token);
        // }

        [Fact]
        public void TestingGetMember()
        {
            PluralkitAPI.Models.Member member = new PKClient(null).GetMember("cewel");

            _ = Assert.IsType<PluralkitAPI.Models.Member>(member);
        }
        /*
        [Fact]
        public void TestingSetMember() 
        { 
            var client = new PKClient("");
            var member = client.SetMember("cewel");

            Assert.IsType<Member>(member);
        } */

    }
}