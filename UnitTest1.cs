using ApiService;
using Grpc.Core;
using Grpc.Net.Client;

namespace UnitTests
{
    public class Tests
    {
        const string NETWORK_ERROR = "#";
        const string UNEXPECTED_FAIL = "3#";

        //private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5088");
        private UserService.UserServiceClient client = new UserService.UserServiceClient(GrpcChannel.ForAddress("http://localhost:5088"));


        const int CargoIdExists = 1;
        const int CargoConstraintsIdExists = 1;
        const int CargoTypesIdExists = 1;
        const int ConstraintsIdExists = 1;
        const int CustomersIdExists = 1;
        const int DriverLicenceIdExists = 1;
        const int DriversIdExists = 1;
        const int OrdersIdExists = 1;
        const int OwnershipsIdExists = 1;
        const int RequestsIdExists = 1;
        const int RequisitesIdExists = 1;
        const int TransportersIdExists = 1;
        const int VehicleTypesIdExists = 1;

        [SetUp]
        public void Setup()
        {
            //client = new UserService.UserServiceClient(channel);
        }

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


        [Test(ExpectedResult = CargoIdExists)]
        public async Task<int> Get()
        {
            try
            {
                CargoObject item = await client.GetCargoAsync(new GetOrDeleteCargoRequest { Id = CargoIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = DriversIdExists)]
        public async Task<int> GetDriverById_ExistingDriver()
        {
            try
            {
                DriversObject item = await client.GetDriverAsync(new GetOrDeleteDriversRequest { Id = DriversIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }


    }
}