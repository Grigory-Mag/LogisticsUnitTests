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
        const int VehicleTransportersTransporterIdExists = 1;
        const int VehicleTransportersVehicleIdExists = 1;

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
        public async Task<int> GetCargoById_Existing()
        {
            try
            {
                var item = await client.GetCargoAsync(new GetOrDeleteCargoRequest { Id = CargoIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = CargoConstraintsIdExists)]
        public async Task<int> GetCargoConstraintsById_Existing()
        {
            try
            {
                var item = await client.GetCargoConstraintAsync(new GetOrDeleteCargoConstraintsRequest { Id = CargoConstraintsIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = CargoTypesIdExists)]
        public async Task<int> GetCargoTypesById_Existing()
        {
            try
            {
                var item = await client.GetCargoTypeAsync(new GetOrDeleteCargoTypesRequest { Id = CargoIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = ConstraintsIdExists)]
        public async Task<int> GetConstraintsById_Existing()
        {
            try
            {
                var item = await client.GetConstraintAsync(new GetOrDeleteConstraintsRequest { Id = ConstraintsIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = CustomersIdExists)]
        public async Task<int> GetCustomerById_Existing()
        {
            try
            {
                var item = await client.GetCustomerAsync(new GetOrDeleteCustomersRequest { Id = CustomersIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = DriverLicenceIdExists)]
        public async Task<int> GetDriverLicenceById_Existing()
        {
            try
            {
                var item = await client.GetDriverAsync(new GetOrDeleteDriversRequest { Id = DriverLicenceIdExists });
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
                var item = await client.GetDriverAsync(new GetOrDeleteDriversRequest { Id = DriversIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = OrdersIdExists)]
        public async Task<int> GetOrdersById_Existing()
        {
            try
            {
                var item = await client.GetOrderAsync(new GetOrDeleteOrdersRequest { Id = OrdersIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = OwnershipsIdExists)]
        public async Task<int> GetOwnershipsById_Existing()
        {
            try
            {
                var item = await client.GetOwnershipAsync(new GetOrDeleteOwnershipsRequest { Id = OwnershipsIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = RequestsIdExists)]
        public async Task<int> GetRequestsById_Existing()
        {
            try
            {
                var item = await client.GetRequestAsync(new GetOrDeleteRequestObjRequest { Id = RequestsIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = RequisitesIdExists)]
        public async Task<int> GetRequisitesById_Existing()
        {
            try
            {
                var item = await client.GetRequisiteAsync(new GetOrDeleteRequisitesRequest { Id = RequisitesIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = TransportersIdExists)]
        public async Task<int> GetTransportersById_Existing()
        {
            try
            {
                var item = await client.GetTransporterAsync(new GetOrDeleteTransportersRequest { Id = TransportersIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = VehicleTypesIdExists)]
        public async Task<int> GetVehicleTypesById_Existing()
        {
            try
            {
                var item = await client.GetVehiclesTypeAsync(new GetOrDeleteVehiclesTypesRequest { Id = VehicleTypesIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = VehicleTransportersTransporterIdExists)]
        public async Task<int> GetVehicleTransporterById_Existing()
        {
            try
            {
                var item = await client.GetVehiclesTransporterAsync(new GetOrDeleteVehiclesTransportersRequest { Id = VehicleTransportersTransporterIdExists });
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