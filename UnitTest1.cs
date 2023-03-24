using LogisticsUnitTests.Data;
using ApiService;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using System.Xml.Linq;

namespace UnitTests
{
    public class Tests
    {
        const string NETWORK_ERROR = "#";
        const string UNEXPECTED_FAIL = "3#";

        //private GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5088");
        private UserService.UserServiceClient client = new UserService.UserServiceClient(GrpcChannel.ForAddress("http://localhost:5088"));




        [SetUp]
        public void Setup()
        {
            
        }


        //public static IEnumerable<TestCaseData> TestData
        //{
        //    get
        //    {
        //        yield return new TestCaseData(cargoObject)
        //        yield return new TestCaseData(report, report.Merchants[4268435971532164].LineItem["EBTPerItem"], 4268435971532164, "EBTPerItem").SetName("ReportMerchantsLineItem");
        //        yield return new TestCaseData(report, report.Merchants[5461324658456716].AggregateTotals, 5461324658456716, "WirelessPerItem").SetName("ReportMerchantsAggregateTotals");
        //        yield return new TestCaseData(report, report.AggregateTotals, null, "AggregateTotals").SetName("ReportAggregateTotals");
        //        yield return new TestCaseData(report, report.AggregateTotals.LineItem["WirelessPerItem"], null, "WirelessPerItem").SetName("ReportAggregateTotalsLineItem");
        //    }
        //}

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
         * [   GET REQUESTS   ]
         */

        [Test(ExpectedResult = Data.CargoIdExists)]
        public async Task<int> GetCargoById_Existing()
        {
            try
            {
                var item = await client.GetCargoAsync(new GetOrDeleteCargoRequest { Id = Data.CargoIdExists });
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
        public async Task<int> GetCargoConstraintsById_Existing()
        {
            try
            {
                var item = await client.GetCargoConstraintAsync(new GetOrDeleteCargoConstraintsRequest
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
        public async Task<int> GetCargoTypesById_Existing()
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

        [Test(ExpectedResult = Data.ConstraintsIdExists)]
        public async Task<int> GetConstraintsById_Existing()
        {
            try
            {
                var item = await client.GetConstraintAsync(new GetOrDeleteConstraintsRequest { Id = Data.ConstraintsIdExists });
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
        public async Task<int> GetCustomerById_Existing()
        {
            try
            {
                var item = await client.GetCustomerAsync(new GetOrDeleteCustomersRequest { Id = Data.CustomersIdExists });
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
        public async Task<int> GetDriverLicenceById_Existing()
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
        public async Task<int> GetDriverById_ExistingDriver()
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

        [Test(ExpectedResult = Data.OrdersIdExists)]
        public async Task<int> GetOrdersById_Existing()
        {
            try
            {
                var item = await client.GetOrderAsync(new GetOrDeleteOrdersRequest { Id = Data.OrdersIdExists });
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
        public async Task<int> GetOwnershipsById_Existing()
        {
            try
            {
                var item = await client.GetOwnershipAsync(new GetOrDeleteOwnershipsRequest { Id = Data.OwnershipsIdExists });
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
        public async Task<int> GetRequestsById_Existing()
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
        public async Task<int> GetRequisitesById_Existing()
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

        [Test(ExpectedResult = Data.TransportersIdExists)]
        public async Task<int> GetTransportersById_Existing()
        {
            try
            {
                var item = await client.GetTransporterAsync(new GetOrDeleteTransportersRequest { Id = Data.TransportersIdExists });
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
        public async Task<int> GetVehicleTypesById_Existing()
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
        public async Task<int> GetVehicleById_Existing()
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

        [Test(ExpectedResult = Data.VehicleTransportersTransporterIdExists)]
        public async Task<int> GetVehicleTransporterById_Existing()
        {
            try
            {
                var item = await client.GetVehiclesTransporterAsync(new GetOrDeleteVehiclesTransportersRequest
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


        /*
         * [      TESTS       ]
         * [   DELETE REQUESTS   ]
         */

        [Test(ExpectedResult = Data.CargoIdExists)]
        public async Task<int> DeleteCargoById_Existing()
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
        public async Task<int> DeleteCargoConstraintsById_Existing()
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
        public async Task<int> DeleteCargoTypesById_Existing()
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
        public async Task<int> DeleteConstraintsById_Existing()
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
        public async Task<int> DeleteCustomerById_Existing()
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
        public async Task<int> DeleteDriverLicenceById_Existing()
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
        public async Task<int> DeleteDriverById_ExistingDriver()
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
        public async Task<int> DeleteOrdersById_Existing()
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
        public async Task<int> DeleteOwnershipsById_Existing()
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
        public async Task<int> DeleteRequestsById_Existing()
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
        public async Task<int> DeleteRequisitesById_Existing()
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
        public async Task<int> DeleteTransportersById_Existing()
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
        public async Task<int> DeleteVehicleTypesById_Existing()
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
        public async Task<int> DeleteVehicleById_Existing()
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
        public async Task<int> DeleteVehicleTransporterById_Existing()
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


        /*
         * [      TESTS          ]
         * [   CREATE REQUESTS   ]
         */
        
        [Test(ExpectedResult = Data.CargoIdExists)]
        public async Task<int> CreateCargoById_Existing()
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
        public async Task<int> CreateCargoTypesById_Existing()
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

        [Test(ExpectedResult = Data.CargoConstraintsCargoIdExists)]
        public async Task<int> CreateCargoConstraintsById_Existing()
        {
            try
            {
                var item = await client.CreateCargoConstraintAsync(new CreateOrUpdateCargoConstraintsRequest { CargoConstraints = Data.cargoConstraintsObject });
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
        public async Task<int> CreateConstraintsById_Existing()
        {
            try
            {
                var item = await client.CreateConstraintAsync(new CreateOrUpdateConstraintsRequest { Constraint = Data.constraintsObject });
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
        public async Task<int> CreateCustomerById_Existing()
        {
            try
            {
                var item = await client.CreateCustomerAsync(new CreateOrUpdateCustomersRequest { Customer = Data.customersObject });
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
        public async Task<int> CreateDriverLicenceById_Existing()
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
        public async Task<int> CreateDriverById_ExistingDriver()
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

        [Test(ExpectedResult = Data.OrdersIdExists)]
        public async Task<int> CreateOrdersById_Existing()
        {
            try
            {
                var item = await client.CreateOrderAsync(new CreateOrUpdateOrdersRequest { Order = Data.ordersObject });
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
        public async Task<int> CreateOwnershipsById_Existing()
        {
            try
            {
                var item = await client.CreateOwnershipAsync(new CreateOrUpdateOwnershipsRequest { Ownership = Data.ownershipsObject });
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
        public async Task<int> CreateRequestsById_Existing()
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
        public async Task<int> CreateRequisitesById_Existing()
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

        [Test(ExpectedResult = Data.TransportersIdExists)]
        public async Task<int> CreateTransportersById_Existing()
        {
            try
            {
                var item = await client.CreateTransporterAsync(new CreateOrUpdateTransportersRequest { Transporter = Data.transportersObject });
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
        public async Task<int> CreateVehicleTypesById_Existing()
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

        [Test(ExpectedResult = Data.VehiclesIdExists)]
        public async Task<int> CreateVehicleById_Existing()
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

        }

        [Test(ExpectedResult = Data.VehicleTransportersTransporterIdExists)]
        public async Task<int> CreateVehicleTransporterById_Existing()
        {
            try
            {
                var item = await client.CreateVehiclesTransporterAsync(new CreateOrUpdateVehiclesTransportersRequest{ VehicleTransporters = Data.vehiclesTransportersObject });
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