using ApiService;
using Grpc.Core;
using Grpc.Net.Client;

namespace UnitTests
{
    public class Tests
    {
        const string NETWORK_ERROR = "#";
        const string UNEXPECTED_FAIL = "3#";

        private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5088");
        private UserService.UserServiceClient client;

        const int TestDriverIdExists = 1;

        [SetUp]
        public void Setup()
        {
            client = new UserService.UserServiceClient(channel);
        }

        [Test(ExpectedResult = TestDriverIdExists)]
        public async Task<int> GetEmployeeById_ExistingEmployee()
        {
            try
            {
                VehiclesTypesObject driver = await client.GetVehiclesTypeAsync(new GetOrDeleteVehiclesTypesRequest { Id = TestDriverIdExists });
                //Assert.AreEqual(employeeObject.Id, IdExist);
                //TestContext.WriteLine($"{PASS,15}\n \'{employeeObject.ToString()}\' \n{PASS,15}");
                Assert.Pass($"{driver}");
                return await Task.FromResult(driver.Id);
            }
            catch (RpcException ex)
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
                return await Task.FromResult(-1);
            }

        }
    }
}