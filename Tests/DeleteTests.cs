using Grpc.Core;
using LogisticsUnitTests.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class DeleteTests : TestsHandler
    {
        private UserService.UserServiceClient client = Data.client;

        /*
        * [      TESTS       ]
        * [   DELETE REQUESTS   ]
        */


        [Test(ExpectedResult = Data.CargoIdExists)]
        public async Task<int> DeleteCargoById_Exists()
        {
            try
            {
                var item = await client.DeleteCargoAsync(new GetOrDeleteCargoRequest { Id = Data.cargoObject.Id }, headers);
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
        public async Task<int> DeleteCargoTypesById_Exists()
        {
            try
            {
                var item = await client.DeleteCargoTypeAsync(new GetOrDeleteCargoTypesRequest { Id = Data.cargoTypesObject.Id }, headers);
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
                var item = await client.DeleteDriverLicenceAsync(new GetOrDeleteDriverLicenceRequest { Id = Data.driverLicenceObject.Id }, headers);
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }


        /// <summary>
        /// Required to get a license separately, from the DB
        /// </summary>
        /// <returns></returns>
        [Test(ExpectedResult = Data.DriversIdExists)]
        public async Task<int> DeleteDriverById_ExistsDriver()
        {
            try
            {
                var item = await client.DeleteDriverAsync(new GetOrDeleteDriversRequest { Id = Data.driversObject.Id }, headers);
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
                var item = await client.DeleteRequestAsync(new GetOrDeleteRequestObjRequest { Id = Data.requestsObject.Id }, headers);
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
                var item = await client.DeleteRequisiteAsync(new GetOrDeleteRequisitesRequest { Id = Data.requestsObject.Id }, headers);
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
                var item = await client.DeleteVehiclesTypeAsync(new GetOrDeleteVehiclesTypesRequest { Id = Data.vehiclesTypesObject.Id }, headers);
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
                var item = await client.DeleteVehicleAsync(new GetOrDeleteVehiclesRequest { Id = Data.vehiclesObject.Id }, headers);
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.RouteObjectIdExists)]
        public async Task<int> DeleteRouteById_Exists()
        {
            try
            {
                var item = await client.DeleteRouteAsync(new GetOrDeleteRouteObjectRequest { Id = Data.routeObject.Id }, headers);
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }
        }

        [Test(ExpectedResult = Data.RequisiteTypeIdExists)]
        public async Task<int> DeleteRequisiteTypeObjectById_Exists()
        {
            try
            {
                var item = await client.DeleteRequisiteTypeAsync(new GetOrDeleteRequisiteTypeRequest { Id = Data.requisiteTypeObject.Id }, headers);
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }
        }

        [Test(ExpectedResult = Data.RoleIdExists)]
        public async Task<int> DeleteRoleObjectById_Exists()
        {
            try
            {
                var item = await client.DeleteRoleAsync(new GetOrDeleteRoleRequest { Id = Data.rolesObject.Id }, headers);
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }
        }

        [Test(ExpectedResult = Data.RouteActionIdExists)]
        public async Task<int> DeleteRouteActionObjectById_Exists()
        {
            try
            {
                var item = await client.DeleteRouteActionAsync(new GetOrDeleteRouteActionsRequest { Id = Data.routeActionsObject.Id }, headers);
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
