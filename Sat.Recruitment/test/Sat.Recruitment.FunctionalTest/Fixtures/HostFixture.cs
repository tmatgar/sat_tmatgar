using System;
using Microsoft.AspNetCore.TestHost;
using Sat.Recruitment.FunctionalTest.Config;

namespace Sat.Recruitment.FunctionalTest.Fixtures
{
    public class HostFixture : IDisposable
    {
        public TestServer Server { get; set; }

        public HostFixture()
        {
            Server = new TestServerBuilder().Build();
        }

        public void Reset()
        {
            Server = new TestServerBuilder().Build();
        }

        public void Dispose()
        {
            Server.Dispose();
        }
    }
}