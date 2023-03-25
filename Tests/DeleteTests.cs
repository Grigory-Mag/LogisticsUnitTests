using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class DeleteTests
    {
        private UserService.UserServiceClient client = new UserService.UserServiceClient(GrpcChannel.ForAddress("http://localhost:5088"));

        const string NETWORK_ERROR = "#";
        const string UNEXPECTED_FAIL = "3#";

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

        /*
        * [      TESTS       ]
        * [   DELETE REQUESTS   ]
        */


        [Test(ExpectedResult = Data.CargoIdExists)]
        public async Task<int> DeleteCargoById_Exists()
        {
            try
            {
                var item = await client.DeleteCargoAsync(new GetOrDeleteCargoRequest { Id = Data.CargoIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.CargoConstraintsCargoIdExists)]
        public async Task<int> DeleteCargoConstraintsById_Exists()
        {
            try
            {
                var item = await client.DeleteCargoConstraintAsync(new GetOrDeleteCargoConstraintsRequest
                { IdCargo = Data.CargoConstraintsCargoIdExists, IdConstraint = Data.CargoConstraintsConstraintIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.IdCargo);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }
        }

        [Test(ExpectedResult = Data.CargoTypesIdExists)]
        public async Task<int> DeleteCargoTypesById_Exists()
        {
            try
            {
                var item = await client.DeleteCargoTypeAsync(new GetOrDeleteCargoTypesRequest { Id = Data.CargoIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.ConstraintsIdExists)]
        public async Task<int> DeleteConstraintsById_Exists()
        {
            try
            {
                var item = await client.DeleteConstraintAsync(new GetOrDeleteConstraintsRequest { Id = Data.ConstraintsIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.CustomersIdExists)]
        public async Task<int> DeleteCustomerById_Exists()
        {
            try
            {
                var item = await client.DeleteCustomerAsync(new GetOrDeleteCustomersRequest { Id = Data.CustomersIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.DriverLicenceIdExists)]
        public async Task<int> DeleteDriverLicenceById_Exists()
        {
            try
            {
                var item = await client.DeleteDriverLicenceAsync(new GetOrDeleteDriverLicenceRequest { Id = Data.DriverLicenceIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.DriversIdExists)]
        public async Task<int> DeleteDriverById_ExistsDriver()
        {
            try
            {
                var item = await client.DeleteDriverAsync(new GetOrDeleteDriversRequest { Id = Data.DriversIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.OrdersIdExists)]
        public async Task<int> DeleteOrdersById_Exists()
        {
            try
            {
                var item = await client.DeleteOrderAsync(new GetOrDeleteOrdersRequest { Id = Data.OrdersIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.OwnershipsIdExists)]
        public async Task<int> DeleteOwnershipsById_Exists()
        {
            try
            {
                var item = await client.DeleteOwnershipAsync(new GetOrDeleteOwnershipsRequest { Id = Data.OwnershipsIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.RequestsIdExists)]
        public async Task<int> DeleteRequestsById_Exists()
        {
            try
            {
                var item = await client.DeleteRequestAsync(new GetOrDeleteRequestObjRequest { Id = Data.RequestsIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.RequisitesIdExists)]
        public async Task<int> DeleteRequisitesById_Exists()
        {
            try
            {
                var item = await client.DeleteRequisiteAsync(new GetOrDeleteRequisitesRequest { Id = Data.RequisitesIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.TransportersIdExists)]
        public async Task<int> DeleteTransportersById_Exists()
        {
            try
            {
                var item = await client.DeleteTransporterAsync(new GetOrDeleteTransportersRequest { Id = Data.TransportersIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.VehicleTypesIdExists)]
        public async Task<int> DeleteVehicleTypesById_Exists()
        {
            try
            {
                var item = await client.DeleteVehiclesTypeAsync(new GetOrDeleteVehiclesTypesRequest { Id = Data.VehicleTypesIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.VehiclesIdExists)]
        public async Task<int> DeleteVehicleById_Exists()
        {
            try
            {
                var item = await client.DeleteVehicleAsync(new GetOrDeleteVehiclesRequest { Id = Data.VehiclesIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.VehicleTransportersTransporterIdExists)]
        public async Task<int> DeleteVehicleTransporterById_Exists()
        {
            try
            {
                var item = await client.DeleteVehiclesTransporterAsync(new GetOrDeleteVehiclesTransportersRequest
                { IdTransporter = Data.VehicleTransportersTransporterIdExists, IdVehicle = Data.VehicleTransportersVehicleIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Transporter);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }
    }
}
