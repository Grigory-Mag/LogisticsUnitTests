using LogisticsUnitTests.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var item = await client.CreateCargoAsync(new CreateOrUpdateCargoRequest { Cargo = Data.cargoObject });
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
                var item = await client.CreateCargoTypeAsync(new CreateOrUpdateCargoTypesRequest { CargoType = Data.cargoTypesObject });
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
                var item = await client.CreateDriverLicenceAsync(new CreateOrUpdateDriverLicenceRequest { DriverLicence = Data.driverLicenceObject });
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
        public async Task<int> CreateDriverById_ExistsDriver()
        {
            try
            {
                var item = await client.CreateDriverAsync(new CreateOrUpdateDriversRequest { Driver = Data.driversObject });
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
                var item = await client.CreateRequestAsync(new CreateOrUpdateRequestObjRequest { Requests = Data.requestsObject });
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
                var item = await client.CreateRequisiteAsync(new CreateOrUpdateRequisitesRequest { Requisite = Data.requisitesObject });
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
                var item = await client.CreateVehiclesTypeAsync(new CreateOrUpdateVehiclesTypesRequest { VehiclesTypes = Data.vehiclesTypesObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

/*        [Test(ExpectedResult = Data.VehiclesIdExists)]
        public async Task<int> CreateVehicleById_Exists()
        {
            try
            {
                var item = await client.CreateVehicleAsync(new CreateOrUpdateVehiclesRequest { Vehicle = Data.vehiclesObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }*/
    }
}
