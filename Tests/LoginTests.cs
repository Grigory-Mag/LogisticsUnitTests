using Grpc.Core;
using LogisticsUnitTests.Data;
using ApiService;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using LogisticsUnitTests.Handler;

namespace UnitTests
{
    internal class LoginTests : TestsHandler
    {

        private UserService.UserServiceClient client = Data.client;

        [Test(ExpectedResult = Data.LoginExists)]
        public async Task<string> LoginUser_Exists()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IlRlc3RVc2VyIiwianRpIjoiNGY4M2U4YTMtNjhmNS00ZjRlLWFmNmUtNGE4NDMzZjdiYTVhIiwiZXhwIjoxNjgxMTg5MjI5LCJpc3MiOiJMb2dpc3RpY0FQSVNlcnZpY2UiLCJhdWQiOiJMb2dpc2l0Y3NBUElTZXJ2aWNlIn0.od-xKXV2s8IVCCMvSbpqOlpbTJKscUZjyMLFiNWVAe0";
            try
            {
                var headers = new Metadata();
                headers.Add("Authorization", $"Bearer {token}");
                var item = await client.LoginUserAsync(new LoginRequest{ Data = Data.loginObject}, headers);
                Assert.Pass($"{item}");
                globalToken = token;
                return await Task.FromResult(item.Token);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult("null");
            }

        }
    }
}
