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
            //AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            //AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);
            var token = globalToken;

            try
            {
                var headers = new Metadata();
                headers.Add("Authorization", $"Bearer {token}");
                Debug.WriteLine( headers );
                var item = await client.GetCargoAsync(new GetOrDeleteCargoRequest { Id = Data.CargoIdExists }, headers);
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
        public async Task<int> GetCargoTypesById_Exists()
        {
            try
            {
                var item = await client.GetCargoTypeAsync(new GetOrDeleteCargoTypesRequest { Id = Data.CargoIdExists });
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
        public async Task<int> GetDriverLicenceById_Exists()
        {
            try
            {
                var item = await client.GetDriverLicenceAsync(new GetOrDeleteDriverLicenceRequest { Id = Data.DriverLicenceIdExists });
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
        public async Task<int> GetDriverById_ExistsDriver()
        {
            try
            {
                var item = await client.GetDriverAsync(new GetOrDeleteDriversRequest { Id = Data.DriversIdExists });
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
        public async Task<int> GetRequestsById_Exists()
        {
            try
            {
                var item = await client.GetRequestAsync(new GetOrDeleteRequestObjRequest { Id = Data.RequestsIdExists });
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
        public async Task<int> GetRequisitesById_Exists()
        {
            try
            {
                var item = await client.GetRequisiteAsync(new GetOrDeleteRequisitesRequest { Id = Data.RequisitesIdExists });
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
        public async Task<int> GetVehicleTypesById_Exists()
        {
            try
            {
                var item = await client.GetVehiclesTypeAsync(new GetOrDeleteVehiclesTypesRequest { Id = Data.VehicleTypesIdExists });
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
        public async Task<int> GetVehicleById_Exists()
        {
            try
            {
                var item = await client.GetVehicleAsync(new GetOrDeleteVehiclesRequest { Id = Data.VehiclesIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = 1)]
        public async Task<int> GetRequest()
        {
            try
            {
                var pupa = await client.GetRequestAsync(new GetOrDeleteRequestObjRequest{ Id = 1});
                pupa.CustomerReq = await client.GetRequisiteAsync(new GetOrDeleteRequisitesRequest { Id = 1});
                var result = await client.UpdateRequestAsync(new CreateOrUpdateRequestObjRequest { Requests = pupa});
                Assert.Pass($"{pupa}");
                return await Task.FromResult(1);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }
    }
}
