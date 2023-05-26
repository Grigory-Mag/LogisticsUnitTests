using Grpc.Core;
using LogisticsUnitTests.Data;
using ApiService;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using LogisticsUnitTests.Handler;

namespace UnitTests
{
    internal class GetTests : TestsHandler
    {

        private UserService.UserServiceClient client = Data.client;

        /*
       * [      TESTS       ]
       * [   GET REQUESTS   ]
       */

        [Test(ExpectedResult = Data.CargoIdExists)]
        public async Task<int> GetCargoById_Exists()
        {
            try
            {
                var item = await client.GetListCargoAsync(new Empty(), headers);
                Assert.Pass($"{item.Cargo.Count}");
                return await Task.FromResult(item.Cargo.Count);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.CargoTypesIdExists)]
        public async Task<int> GetCargoTypesById_Exists()
        {
            try
            {
                var item = await client.GetListCargoTypesAsync(new Empty(), headers);
                Assert.Pass($"{item.CargoType.Count}");
                return await Task.FromResult(item.CargoType.Count);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.DriverLicenceIdExists)]
        public async Task<int> GetDriverLicenceById_Exists()
        {
            try
            {
                var item = await client.GetListDriverLicencesAsync(new Empty(), headers);
                Assert.Pass($"{item.DriverLicence.Count}");
                return await Task.FromResult(item.DriverLicence.Count);
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
        public async Task<int> GetDriverById_ExistsDriver()
        {
            try
            {
                var item = await client.GetListDriversAsync(new Empty(), headers);
                Assert.Pass($"{item.Drivers.Count}");
                return await Task.FromResult(item.Drivers.Count);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.RequestsIdExists)]
        public async Task<int> GetRequestsById_Exists()
        {
            try
            {
                var item = await client.GetListRequestsAsync(new Empty(), headers);
                Assert.Pass($"{item.Requests.Count}");
                return await Task.FromResult(item.Requests.Count);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.RequisitesIdExists)]
        public async Task<int> GetRequisitesById_Exists()
        {
            try
            {
                var item = await client.GetListRequisitesAsync(new Empty(), headers);
                Assert.Pass($"{item.Requisites.Count}");
                return await Task.FromResult(item.Requisites.Count);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.VehicleTypesIdExists)]
        public async Task<int> GetVehicleTypesById_Exists()
        {
            try
            {
                var item = await client.GetListVehiclesTypesAsync(new Empty(), headers);
                Assert.Pass($"{item.VehiclesTypes.Count}");
                return await Task.FromResult(item.VehiclesTypes.Count);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.VehiclesIdExists)]
        public async Task<int> GetVehicleById_Exists()
        {
            try
            {
                var item = await client.GetListVehiclesAsync(new Empty(), headers);
                Assert.Pass($"{item.Vehicle.Count}");
                return await Task.FromResult(item.Vehicle.Count);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = Data.RouteObjectIdExists)]
        public async Task<int> GetRouteById_Exists()
        {
            try
            {
                var item = await client.GetListRouteAsync(new Empty(), headers);
                Assert.Pass($"{item.RouteObjects.Count}");
                return await Task.FromResult(item.RouteObjects.Count);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }
        }

        [Test(ExpectedResult = Data.RequisiteTypeIdExists)]
        public async Task<int> GetRequisiteTypeObjectById_Exists()
        {
            try
            {
                var item = await client.GetListRequisiteTypesAsync(new Empty(), headers);
                Assert.Pass($"{item.RequisiteType.Count}");
                return await Task.FromResult(item.RequisiteType.Count);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }
        }

        [Test(ExpectedResult = Data.RoleIdExists)]
        public async Task<int> GetRoleObjectById_Exists()
        {
            try
            {
                var item = await client.GetListRolesAsync(new Empty(), headers);
                Assert.Pass($"{item.RolesObject.Count}");
                return await Task.FromResult(item.RolesObject.Count);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }
        }

        [Test(ExpectedResult = Data.RouteActionIdExists)]
        public async Task<int> GetRouteActionObjectById_Exists()
        {
            try
            {
                var item = await client.GetListRouteActionsAsync(new Empty(), headers);
                Assert.Pass($"{item.RouteActionsObject.Count}");
                return await Task.FromResult(item.RouteActionsObject.Count);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }
        }
    }
}
