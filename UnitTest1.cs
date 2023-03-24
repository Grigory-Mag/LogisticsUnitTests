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
        const int CargoConstraintsCargoIdExists = 1;
        const int CargoConstraintsConstraintIdExists = 1;
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
        const int VehiclesIdExists = 1;
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

        [Test(ExpectedResult = CargoConstraintsCargoIdExists)]
        public async Task<int> GetCargoConstraintsById_Existing()
        {
            try
            {
                var item = await client.GetCargoConstraintAsync(new GetOrDeleteCargoConstraintsRequest 
                { IdCargo = CargoConstraintsCargoIdExists, IdConstraint = CargoConstraintsConstraintIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.IdCargo);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        /*
         * [      TESTS       ]
         * [   GET REQUESTS   ]
         */

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
                var item = await client.GetDriverLicenceAsync(new GetOrDeleteDriverLicenceRequest { Id = DriverLicenceIdExists });
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

        [Test(ExpectedResult = VehiclesIdExists)]
        public async Task<int> GetVehicleById_Existing()
        {
            try
            {
                var item = await client.GetVehicleAsync(new GetOrDeleteVehiclesRequest { Id = VehiclesIdExists });
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
                var item = await client.GetVehiclesTransporterAsync(new GetOrDeleteVehiclesTransportersRequest 
                { IdTransporter = VehicleTransportersTransporterIdExists, IdVehicle = VehicleTransportersVehicleIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Transporter);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }


        /*
         * [      TESTS       ]
         * [   DELETE REQUESTS   ]
         */


        [Test(ExpectedResult = CargoTypesIdExists)]
        public async Task<int> DeleteCargoTypesById_Existing()
        {
            try
            {
                var item = await client.DeleteCargoTypeAsync(new GetOrDeleteCargoTypesRequest { Id = CargoIdExists });
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
        public async Task<int> DeleteConstraintsById_Existing()
        {
            try
            {
                var item = await client.DeleteConstraintAsync(new GetOrDeleteConstraintsRequest { Id = ConstraintsIdExists });
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
        public async Task<int> DeleteCustomerById_Existing()
        {
            try
            {
                var item = await client.DeleteCustomerAsync(new GetOrDeleteCustomersRequest { Id = CustomersIdExists });
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
        public async Task<int> DeleteDriverLicenceById_Existing()
        {
            try
            {
                var item = await client.DeleteDriverLicenceAsync(new GetOrDeleteDriverLicenceRequest { Id = DriverLicenceIdExists });
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
        public async Task<int> DeleteDriverById_ExistingDriver()
        {
            try
            {
                var item = await client.DeleteDriverAsync(new GetOrDeleteDriversRequest { Id = DriversIdExists });
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
        public async Task<int> DeleteOrdersById_Existing()
        {
            try
            {
                var item = await client.DeleteOrderAsync(new GetOrDeleteOrdersRequest { Id = OrdersIdExists });
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
        public async Task<int> DeleteOwnershipsById_Existing()
        {
            try
            {
                var item = await client.DeleteOwnershipAsync(new GetOrDeleteOwnershipsRequest { Id = OwnershipsIdExists });
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
        public async Task<int> DeleteRequestsById_Existing()
        {
            try
            {
                var item = await client.DeleteRequestAsync(new GetOrDeleteRequestObjRequest { Id = RequestsIdExists });
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
        public async Task<int> DeleteRequisitesById_Existing()
        {
            try
            {
                var item = await client.DeleteRequisiteAsync(new GetOrDeleteRequisitesRequest { Id = RequisitesIdExists });
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
        public async Task<int> DeleteTransportersById_Existing()
        {
            try
            {
                var item = await client.DeleteTransporterAsync(new GetOrDeleteTransportersRequest { Id = TransportersIdExists });
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
        public async Task<int> DeleteVehicleTypesById_Existing()
        {
            try
            {
                var item = await client.DeleteVehiclesTypeAsync(new GetOrDeleteVehiclesTypesRequest { Id = VehicleTypesIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = VehiclesIdExists)]
        public async Task<int> DeleteVehicleById_Existing()
        {
            try
            {
                var item = await client.DeleteVehicleAsync(new GetOrDeleteVehiclesRequest { Id = VehiclesIdExists });
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
        public async Task<int> DeleteVehicleTransporterById_Existing()
        {
            try
            {
                var item = await client.DeleteVehiclesTransporterAsync(new GetOrDeleteVehiclesTransportersRequest
                { IdTransporter = VehicleTransportersTransporterIdExists, IdVehicle = VehicleTransportersVehicleIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Transporter);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }


        /*
         * [      TESTS       ]
         * [   CREATE REQUESTS   ]
         */


    }
}