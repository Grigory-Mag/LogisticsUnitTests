using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class UpdateTests
    {
        const string NETWORK_ERROR = "#";
        const string UNEXPECTED_FAIL = "3#";

        private UserService.UserServiceClient client = new UserService.UserServiceClient(GrpcChannel.ForAddress("http://localhost:5088"));

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
        * [      TESTS          ]
        * [   UPDATE REQUESTS   ]
        */

        [Test(ExpectedResult = Data.CargoIdExists)]
        public async Task<int> UpdateCargoById_Exists()
        {
            try
            {
                var item = await client.UpdateCargoAsync(new CreateOrUpdateCargoRequest { Cargo = Data.cargoObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.CargoTypesIdExists)]
        public async Task<int> UpdateCargoTypesById_Exists()
        {
            try
            {
                var item = await client.UpdateCargoTypeAsync(new CreateOrUpdateCargoTypesRequest { CargoType = Data.cargoTypesObject });
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
        public async Task<int> UpdateCargoConstraintsById_Exists()
        {
            try
            {
                var item = await client.UpdateCargoConstraintAsync(new CreateOrUpdateCargoConstraintsRequest { CargoConstraints = Data.cargoConstraintsObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.IdCargo);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }
        }

        [Test(ExpectedResult = Data.ConstraintsIdExists)]
        public async Task<int> UpdateConstraintsById_Exists()
        {
            try
            {
                var item = await client.UpdateConstraintsAsync(new CreateOrUpdateConstraintsRequest { Constraint = Data.constraintsObject });
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
        public async Task<int> UpdateCustomerById_Exists()
        {
            try
            {
                var item = await client.UpdateCustomerAsync(new CreateOrUpdateCustomersRequest { Customer = Data.customersObject });
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
        public async Task<int> UpdateDriverLicenceById_Exists()
        {
            try
            {
                var item = await client.UpdateDriverLicenceAsync(new CreateOrUpdateDriverLicenceRequest { DriverLicence = Data.driverLicenceObject });
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
        public async Task<int> UpdateDriverById_ExistsDriver()
        {
            try
            {
                var item = await client.UpdateDriverAsync(new CreateOrUpdateDriversRequest { Driver = Data.driversObject });
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
        public async Task<int> UpdateOrdersById_Exists()
        {
            try
            {
                var item = await client.UpdateOrderAsync(new CreateOrUpdateOrdersRequest { Order = Data.ordersObject });
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
        public async Task<int> UpdateOwnershipsById_Exists()
        {
            try
            {
                var item = await client.UpdateOwnershipAsync(new CreateOrUpdateOwnershipsRequest { Ownership = Data.ownershipsObject });
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
        public async Task<int> UpdateRequestsById_Exists()
        {
            try
            {
                var item = await client.UpdateRequestAsync(new CreateOrUpdateRequestObjRequest { Requests = Data.requestsObject });
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
        public async Task<int> UpdateRequisitesById_Exists()
        {
            try
            {
                var item = await client.UpdateRequisiteAsync(new CreateOrUpdateRequisitesRequest { Requisite = Data.requisitesObject });
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
        public async Task<int> UpdateTransportersById_Exists()
        {
            try
            {
                var item = await client.UpdateTransporterAsync(new CreateOrUpdateTransportersRequest { Transporter = Data.transportersObject });
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
        public async Task<int> UpdateVehicleTypesById_Exists()
        {
            try
            {
                var item = await client.UpdateVehiclesTypeAsync(new CreateOrUpdateVehiclesTypesRequest { VehiclesTypes = Data.vehiclesTypesObject });
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
        public async Task<int> UpdateVehicleById_Exists()
        {
            try
            {
                var item = await client.UpdateVehicleAsync(new CreateOrUpdateVehiclesRequest { Vehicle = Data.vehiclesObject });
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
        public async Task<int> UpdateVehicleTransporterById_Exists()
        {
            try
            {
                var item = await client.UpdateVehiclesTransporterAsync(new CreateOrUpdateVehiclesTransportersRequest { VehicleTransporters = Data.vehiclesTransportersObject });
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
