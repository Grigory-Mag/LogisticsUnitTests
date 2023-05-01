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
                var item = await client.DeleteCargoAsync(new GetOrDeleteCargoRequest { Id = 3});
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

/*        [Test(ExpectedResult = Data.VehicleTransportersTransporterIdExists)]
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

        }*/
    }
}
