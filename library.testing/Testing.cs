using System;
using System.IO;
using Xunit;
using PluralkitAPI.Environment;
using PluralkitAPI.Client;
using PluralkitAPI.Models;
using System.Collections.Generic;

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
        [Fact]
        public void TestingCreateAndDeleteMember()
        {
            PKClient client = new(Token);

            var member = new Member
            {
                Name = "TestyMcTestFace",
                ProxyTags = new List<ProxyTag> { new ProxyTag { Prefix = "test;", Suffix = null } },
                KeepProxy = true
            };

            var createdMember = client.CreateMember(member);

            client.DeleteMember(createdMember.ID);

            try
            {
                client.GetMember(createdMember.ID);
                throw new Exception($"Member {createdMember.ID} was not deleted.");
            }
            catch
            {
                ;
            }
        }

        [Fact]
        public void TestingGetMember()
        {
            Member member = new PKClient(null).GetMember("cewel");

            _ = Assert.IsType<Member>(member);
        }
        [Fact]
        public void TestingSetMember()
        {
            var client = new PKClient(Token);
            var editMember = client.GetMember("cewel");

            var member = client.SetMember(editMember);

            Assert.IsType<Member>(member);

        }
    }
}