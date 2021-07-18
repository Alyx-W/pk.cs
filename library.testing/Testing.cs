using System;
using Xunit;
using library;
using PluralkitAPI.Client;
using PluralkitAPI.Models;
using System.Collections.Generic;


namespace library.testing
{
    public class Test
    {   
        [Fact]
        public void TestingGetSystem()
        {
            PKClient client = new PKClient();
            var system = client.GetSystem("lmzyh");

            Assert.IsType<PluralkitAPI.Models.System> (system);
        }

        [Fact]
        public void TestingGetMember()
        {
            PKClient client = new PKClient();
            var member = client.GetMember("cewel");

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