using LogisticsUnitTests.Data;
using ApiService;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using System.Xml.Linq;

namespace UnitTests
{
    public class Tests
    {
        const string NETWORK_ERROR = "#";
        const string UNEXPECTED_FAIL = "3#";

        //private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5088");
        private UserService.UserServiceClient client = new UserService.UserServiceClient(GrpcChannel.ForAddress("http://localhost:5088"));




        [SetUp]
        public void Setup()
        {
            
        }


        //public static IEnumerable<TestCaseData> TestData
        //{
        //    get
        //    {
        //        yield return new TestCaseData(cargoObject)
        //        yield return new TestCaseData(report, report.Merchants[4268435971532164].LineItem["EBTPerItem"], 4268435971532164, "EBTPerItem").SetName("ReportMerchantsLineItem");
        //        yield return new TestCaseData(report, report.Merchants[5461324658456716].AggregateTotals, 5461324658456716, "WirelessPerItem").SetName("ReportMerchantsAggregateTotals");
        //        yield return new TestCaseData(report, report.AggregateTotals, null, "AggregateTotals").SetName("ReportAggregateTotals");
        //        yield return new TestCaseData(report, report.AggregateTotals.LineItem["WirelessPerItem"], null, "WirelessPerItem").SetName("ReportAggregateTotalsLineItem");
        //    }
        //}

        private void ExceptionsHandler(RpcException ex)
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