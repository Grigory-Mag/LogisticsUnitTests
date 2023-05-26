using LogisticsUnitTests.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class UpdateTests : TestsHandler
    {

        private UserService.UserServiceClient client = Data.client;

        /*
        * [      TESTS          ]
        * [   UPDATE REQUESTS   ]
        */

        [Test(ExpectedResult = Data.CargoIdExists)]
        public async Task<int> UpdateCargoById_Exists()
        {
            try
            {
                var item = await client.UpdateCargoAsync(new CreateOrUpdateCargoRequest { Cargo = Data.cargoObject }, headers);
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
                var item = await client.UpdateCargoTypeAsync(new CreateOrUpdateCargoTypesRequest { CargoType = Data.cargoTypesObject }, headers);
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
                var item = await client.UpdateDriverLicenceAsync(new CreateOrUpdateDriverLicenceRequest { DriverLicence = Data.driverLicenceObject }, headers);
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
        public async Task<int> UpdateDriverById_ExistsDriver()
        {
            try
            {
                var license = (await client.GetListDriverLicencesAsync(new Empty(), headers)).DriverLicence.First(x => x.Id == 777);
                var driver = Data.driversObject;
                driver.Licence = license;
                var item = await client.UpdateDriverAsync(new CreateOrUpdateDriversRequest { Driver = driver }, headers);
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
                var vehicle = (await client.GetListVehiclesAsync(new Empty(), headers)).Vehicle.First(x => x.Id == 777);
                var requestObj = Data.requestsObject;
                requestObj.Vehicle = vehicle;
                var item = await client.UpdateRequestAsync(new CreateOrUpdateRequestObjRequest { Requests = requestObj }, headers);
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

                var role = (await client.GetListRolesAsync(new Empty(), headers)).RolesObject.First(x => x.Id == 777);
                var requisite = (await client.GetListRolesAsync(new Empty(), headers)).RolesObject.First(x => x.Id == 777);
                var type = (await client.GetListRequisiteTypesAsync(new Empty(), headers)).RequisiteType.First(x => x.Id == 777);
                var data = Data.requisitesObject;
                data.Type = type;
                data.Role = role;
                var item = await client.UpdateRequisiteAsync(new CreateOrUpdateRequisitesRequest { Requisite = data }, headers);
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
                var item = await client.UpdateVehiclesTypeAsync(new CreateOrUpdateVehiclesTypesRequest { VehiclesTypes = Data.vehiclesTypesObject }, headers);
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
                var item = await client.UpdateVehicleAsync(new CreateOrUpdateVehiclesRequest { Vehicle = Data.vehiclesObject }, headers);
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
        public async Task<int> UpdateRouteById_Exists()
        {
            try
            {
                var item = await client.UpdateRouteAsync(new CreateOrUpdateRouteObjectRequest { RouteObject = Data.routeObject }, headers);
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
        public async Task<int> UpdateRequisiteTypeObjectById_Exists()
        {
            try
            {
                var item = await client.UpdateRequisiteTypeAsync(new CreateOrUpdateRequisiteTypeRequest { RequisiteType = Data.requisiteTypeObject }, headers);
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
        public async Task<int> UpdateRoleObjectById_Exists()
        {
            try
            {
                var item = await client.UpdateRoleAsync(new CreateOrUpdateRoleRequest { RoleObject = Data.rolesObject }, headers);
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
        public async Task<int> UpdateRouteActionObjectById_Exists()
        {
            try
            {
                var item = await client.UpdateRouteActionAsync(new CreateOrUpdateRouteActionsRequest { RouteAction = Data.routeActionsObject }, headers);
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
