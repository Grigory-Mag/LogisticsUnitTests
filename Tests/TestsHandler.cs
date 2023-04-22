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
        public string globalToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImNsb3duIiwianRpIjoiNzhhZWViZTctNzkyOS00MDg4LTg3MjUtMzM4NjJiMDEzZTFjIiwiZXhwIjoxNjgxNDY1MzU0LCJpc3MiOiJMb2dpc3RpY0FQSVNlcnZpY2UiLCJhdWQiOiJMb2dpc2l0Y3NBUElTZXJ2aWNlIn0.YwoAVFz5eNturWjL_AN0GmULV0Rjxr2TlOIgjw2h3ZI";

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
