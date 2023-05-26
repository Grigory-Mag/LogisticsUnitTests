using LogisticsUnitTests.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class CreateTests : TestsHandler
    {
        private UserService.UserServiceClient client = Data.client;

        

        /*
        * [      TESTS          ]
        * [   CREATE REQUESTS   ]
        */

        [Test(ExpectedResult = Data.CargoIdExists)]
        public async Task<int> CreateCargoById_Exists()
        {
            try
            {
                var item = await client.CreateCargoAsync(new CreateOrUpdateCargoRequest { Cargo = Data.cargoObject }, headers);
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
        public async Task<int> CreateCargoTypesById_Exists()
        {
            try
            {
                var item = await client.CreateCargoTypeAsync(new CreateOrUpdateCargoTypesRequest { CargoType = Data.cargoTypesObject }, headers);
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
        public async Task<int> CreateDriverLicenceById_Exists()
        {
            try
            {
                var item = await client.CreateDriverLicenceAsync(new CreateOrUpdateDriverLicenceRequest { DriverLicence = Data.driverLicenceObject }, headers);
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
        public async Task<int> CreateDriverById_ExistsDriver()
        {
            try
            {
                var license = (await client.GetListDriverLicencesAsync(new Empty(), headers)).DriverLicence.First(x => x.Id == 777);
                var driver = Data.driversObject;
                driver.Licence = license;
                var item = await client.CreateDriverAsync(new CreateOrUpdateDriversRequest { Driver = driver}, headers);
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
        public async Task<int> CreateRequestsById_Exists()
        {
            try
            {
                var vehicle = (await client.GetListVehiclesAsync(new Empty(), headers)).Vehicle.First(x => x.Id == 777);
                var requestObj = Data.requestsObject;
                requestObj.Vehicle = vehicle;
                var item = await client.CreateRequestAsync(new CreateOrUpdateRequestObjRequest { Requests = requestObj }, headers);
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
        public async Task<int> CreateRequisitesById_Exists()
        {
            try
            {
                var role = (await client.GetListRolesAsync(new Empty(), headers)).RolesObject.First(x => x.Id == 777);
                var requisite = (await client.GetListRolesAsync(new Empty(), headers)).RolesObject.First(x => x.Id == 777);
                var type = (await client.GetListRequisiteTypesAsync(new Empty(), headers)).RequisiteType.First(x => x.Id == 777);
                var data = Data.requisitesObject;
                data.Type = type;
                data.Role = role;
                var item = await client.CreateRequisiteAsync(new CreateOrUpdateRequisitesRequest { Requisite = data}, headers);
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
        public async Task<int> CreateVehicleTypesById_Exists()
        {
            try
            {
                var item = await client.CreateVehiclesTypeAsync(new CreateOrUpdateVehiclesTypesRequest { VehiclesTypes = Data.vehiclesTypesObject }, headers);
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
        public async Task<int> CreateVehicleById_Exists()
        {
            try
            {
                var item = await client.CreateVehicleAsync(new CreateOrUpdateVehiclesRequest { Vehicle = Data.vehiclesObject }, headers);
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
        public async Task<int> CreateRouteById_Exists()
        {
            try
            {
                var item = await client.CreateRouteAsync(new CreateOrUpdateRouteObjectRequest{ RouteObject = Data.routeObject }, headers);
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
        public async Task<int> CreateRequisiteTypeObjectById_Exists()
        {
            try
            {
                var item = await client.CreateRequisiteTypeAsync(new CreateOrUpdateRequisiteTypeRequest{ RequisiteType = Data.requisiteTypeObject}, headers);
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
        public async Task<int> CreateRoleObjectById_Exists()
        {
            try
            {
                var item = await client.CreateRoleAsync(new CreateOrUpdateRoleRequest{ RoleObject = Data.rolesObject}, headers);
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
        public async Task<int> CreateRouteActionObjectById_Exists()
        {
            try
            {
                var item = await client.CreateRouteActionAsync(new CreateOrUpdateRouteActionsRequest{ RouteAction = Data.routeActionsObject}, headers);
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
