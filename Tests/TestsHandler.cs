using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsUnitTests.Handler
{
    public class TestsHandler
    {
        const string NETWORK_ERROR = "#";
        const string UNEXPECTED_FAIL = "3#";
        public string globalToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImFsZXgiLCJqdGkiOiJlZjljMDc3YS1hNmFmLTQzZmEtYmIwZS1hZDk5MDgwNDRhZDgiLCJleHAiOjE2ODQ0ODI4MjUsImlzcyI6IkxvZ2lzdGljQVBJU2VydmljZSIsImF1ZCI6IkxvZ2lzaXRjc0FQSVNlcnZpY2UifQ.nCalbD_ng2vAGqAZXpFuIO0WXQGmEzj_ZOILKXqrQYI";
        public Metadata headers = new Metadata();

        [SetUp]
        public void OnLaunch()
        {
            headers.Add("Authorization", $"Bearer {globalToken}");
        }

        public static void ExceptionsHandler(RpcException ex)
        {
            switch (ex.StatusCode)
            {
                case StatusCode.Unavailable:
                case StatusCode.Unimplemented:
                case StatusCode.Unknown:
                case StatusCode.Internal:
                case StatusCode.ResourceExhausted:
                    Assert.Fail($"{NETWORK_ERROR,15}\n \'{ex.Message}\' \n{NETWORK_ERROR,15}");
                    break;
                default:
                    Assert.Fail($"{UNEXPECTED_FAIL,15}\n \'{ex.Message}\' \n{UNEXPECTED_FAIL,15}");
                    break;
            }
        }
    }
}
