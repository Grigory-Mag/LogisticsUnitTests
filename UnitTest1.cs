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


        const int CargoIdExists = 1;
        const int CargoConstraintsCargoIdExists = 1;
        const int CargoConstraintsConstraintIdExists = 1;
        const int CargoTypesIdExists = 1;
        const int ConstraintsIdExists = 1;
        const int CustomersIdExists = 1;
        const int DriverLicenceIdExists = 1;
        const int DriversIdExists = 1;
        const int OrdersIdExists = 1;
        const int OwnershipsIdExists = 1;
        const int RequestsIdExists = 1;
        const int RequisitesIdExists = 1;
        const int TransportersIdExists = 1;
        const int VehicleTypesIdExists = 1;
        const int VehiclesIdExists = 1;
        const int VehicleTransportersTransporterIdExists = 1;
        const int VehicleTransportersVehicleIdExists = 1;

        CargoObject cargoObject = new CargoObject()
        {
            Id = 1,
            Constraints = 1,
            Name = "Name",
            Price = 1,
            Type = 1,
            Volume = 1,
            Weight = 1,
        };
        CargoConstraintsObject cargoConstraintsObject = new CargoConstraintsObject()
        {
            IdCargo = 1,
            IdConstraint = 1,
        };
        CargoTypesObject cargoTypesObject = new CargoTypesObject()
        {
            Id = 1,
                Name = "Name"
            };
        ConstraintsObject constraintsObject = new ConstraintsObject()
        {
            Id = 1,
            Desc = "Desc"
        };
        CustomersObject customersObject = new CustomersObject()
        {
            Id = 1,
            Cargo = 1,
            Requisite = 1
        };
        DriverLicenceObject driverLicenceObject = new DriverLicenceObject()
        {
            Id = 1,
            Date = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime().ToUniversalTime()),
            Number = 1234,
            Series = 1241
        };
        DriversObject driversObject = new DriversObject()
        {
            Id = 1,
            Licence = 1,
            Name = "Name",
            Patronymic = "Patr",
            Sanitation = true,
            Surname = "Surn"
        };
        OrdersObject ordersObject = new OrdersObject()
        {
            Id = 1,
            Cargo = 1,
            Date = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime())
        };
        OwnershipsObject ownershipsObject = new OwnershipsObject()
        {
            Id = 1,
            Name = "Name"
        };
        RequestsObject requestsObject = new RequestsObject()
        {
            Id = 1,
            Conditions = true,
            Order = 1,
            Price = 1,
            Vehicle = 1
        };
        RequisitesObject requisitesObject = new RequisitesObject()
        {
            Id = 1,
            Ceo = "ООО \"Рога и копыта\"",
            Inn = "123456",
            LegalAddress = "1",
            Ownership = 1,
            Pts = 1
        };
        TransportersObject transportersObject = new TransportersObject()
        {
            Id = 1,
            Name = "1"
        };
        VehiclesTypesObject vehiclesTypesObject = new VehiclesTypesObject()
        {
            Id = 1,
            Name = "1"
        };
        VehiclesObject vehiclesObject = new VehiclesObject()
        {
            Id = 1,
            Driver = 1,
            Number = "12314",
            Owner = 1,
            Type = 1
        };
        VehiclesTransportersObject vehiclesTransportersObject = new VehiclesTransportersObject()
        {
            Transporter = 1,
            Vehicle = 1
        };

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

        [Test(ExpectedResult = CargoIdExists)]
        public async Task<int> GetCargoById_Existing()
        {
            try
            {
                var item = await client.GetCargoAsync(new GetOrDeleteCargoRequest { Id = CargoIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = CargoConstraintsCargoIdExists)]
        public async Task<int> GetCargoConstraintsById_Existing()
        {
            try
            {
                var item = await client.GetCargoConstraintAsync(new GetOrDeleteCargoConstraintsRequest
                { IdCargo = CargoConstraintsCargoIdExists, IdConstraint = CargoConstraintsConstraintIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.IdCargo);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = CargoTypesIdExists)]
        public async Task<int> GetCargoTypesById_Existing()
        {
            try
            {
                var item = await client.GetCargoTypeAsync(new GetOrDeleteCargoTypesRequest { Id = CargoIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = ConstraintsIdExists)]
        public async Task<int> GetConstraintsById_Existing()
        {
            try
            {
                var item = await client.GetConstraintAsync(new GetOrDeleteConstraintsRequest { Id = ConstraintsIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = CustomersIdExists)]
        public async Task<int> GetCustomerById_Existing()
        {
            try
            {
                var item = await client.GetCustomerAsync(new GetOrDeleteCustomersRequest { Id = CustomersIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = DriverLicenceIdExists)]
        public async Task<int> GetDriverLicenceById_Existing()
        {
            try
            {
                var item = await client.GetDriverLicenceAsync(new GetOrDeleteDriverLicenceRequest { Id = DriverLicenceIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = DriversIdExists)]
        public async Task<int> GetDriverById_ExistingDriver()
        {
            try
            {
                var item = await client.GetDriverAsync(new GetOrDeleteDriversRequest { Id = DriversIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = OrdersIdExists)]
        public async Task<int> GetOrdersById_Existing()
        {
            try
            {
                var item = await client.GetOrderAsync(new GetOrDeleteOrdersRequest { Id = OrdersIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = OwnershipsIdExists)]
        public async Task<int> GetOwnershipsById_Existing()
        {
            try
            {
                var item = await client.GetOwnershipAsync(new GetOrDeleteOwnershipsRequest { Id = OwnershipsIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = RequestsIdExists)]
        public async Task<int> GetRequestsById_Existing()
        {
            try
            {
                var item = await client.GetRequestAsync(new GetOrDeleteRequestObjRequest { Id = RequestsIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = RequisitesIdExists)]
        public async Task<int> GetRequisitesById_Existing()
        {
            try
            {
                var item = await client.GetRequisiteAsync(new GetOrDeleteRequisitesRequest { Id = RequisitesIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = TransportersIdExists)]
        public async Task<int> GetTransportersById_Existing()
        {
            try
            {
                var item = await client.GetTransporterAsync(new GetOrDeleteTransportersRequest { Id = TransportersIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = VehicleTypesIdExists)]
        public async Task<int> GetVehicleTypesById_Existing()
        {
            try
            {
                var item = await client.GetVehiclesTypeAsync(new GetOrDeleteVehiclesTypesRequest { Id = VehicleTypesIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = VehiclesIdExists)]
        public async Task<int> GetVehicleById_Existing()
        {
            try
            {
                var item = await client.GetVehicleAsync(new GetOrDeleteVehiclesRequest { Id = VehiclesIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = VehicleTransportersTransporterIdExists)]
        public async Task<int> GetVehicleTransporterById_Existing()
        {
            try
            {
                var item = await client.GetVehiclesTransporterAsync(new GetOrDeleteVehiclesTransportersRequest
                { IdTransporter = VehicleTransportersTransporterIdExists, IdVehicle = VehicleTransportersVehicleIdExists });
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

        [Test(ExpectedResult = CargoIdExists)]
        public async Task<int> DeleteCargoById_Existing()
        {
            try
            {
                var item = await client.DeleteCargoAsync(new GetOrDeleteCargoRequest { Id = CargoIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = CargoTypesIdExists)]
        public async Task<int> DeleteCargoTypesById_Existing()
        {
            try
            {
                var item = await client.DeleteCargoTypeAsync(new GetOrDeleteCargoTypesRequest { Id = CargoIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = ConstraintsIdExists)]
        public async Task<int> DeleteConstraintsById_Existing()
        {
            try
            {
                var item = await client.DeleteConstraintAsync(new GetOrDeleteConstraintsRequest { Id = ConstraintsIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = CustomersIdExists)]
        public async Task<int> DeleteCustomerById_Existing()
        {
            try
            {
                var item = await client.DeleteCustomerAsync(new GetOrDeleteCustomersRequest { Id = CustomersIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = DriverLicenceIdExists)]
        public async Task<int> DeleteDriverLicenceById_Existing()
        {
            try
            {
                var item = await client.DeleteDriverLicenceAsync(new GetOrDeleteDriverLicenceRequest { Id = DriverLicenceIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = DriversIdExists)]
        public async Task<int> DeleteDriverById_ExistingDriver()
        {
            try
            {
                var item = await client.DeleteDriverAsync(new GetOrDeleteDriversRequest { Id = DriversIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = OrdersIdExists)]
        public async Task<int> DeleteOrdersById_Existing()
        {
            try
            {
                var item = await client.DeleteOrderAsync(new GetOrDeleteOrdersRequest { Id = OrdersIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = OwnershipsIdExists)]
        public async Task<int> DeleteOwnershipsById_Existing()
        {
            try
            {
                var item = await client.DeleteOwnershipAsync(new GetOrDeleteOwnershipsRequest { Id = OwnershipsIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = RequestsIdExists)]
        public async Task<int> DeleteRequestsById_Existing()
        {
            try
            {
                var item = await client.DeleteRequestAsync(new GetOrDeleteRequestObjRequest { Id = RequestsIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = RequisitesIdExists)]
        public async Task<int> DeleteRequisitesById_Existing()
        {
            try
            {
                var item = await client.DeleteRequisiteAsync(new GetOrDeleteRequisitesRequest { Id = RequisitesIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = TransportersIdExists)]
        public async Task<int> DeleteTransportersById_Existing()
        {
            try
            {
                var item = await client.DeleteTransporterAsync(new GetOrDeleteTransportersRequest { Id = TransportersIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = VehicleTypesIdExists)]
        public async Task<int> DeleteVehicleTypesById_Existing()
        {
            try
            {
                var item = await client.DeleteVehiclesTypeAsync(new GetOrDeleteVehiclesTypesRequest { Id = VehicleTypesIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = VehiclesIdExists)]
        public async Task<int> DeleteVehicleById_Existing()
        {
            try
            {
                var item = await client.DeleteVehicleAsync(new GetOrDeleteVehiclesRequest { Id = VehiclesIdExists });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = VehicleTransportersTransporterIdExists)]
        public async Task<int> DeleteVehicleTransporterById_Existing()
        {
            try
            {
                var item = await client.DeleteVehiclesTransporterAsync(new GetOrDeleteVehiclesTransportersRequest
                { IdTransporter = VehicleTransportersTransporterIdExists, IdVehicle = VehicleTransportersVehicleIdExists });
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
        
        [Test(ExpectedResult = CargoIdExists)]
        public async Task<int> CreateCargoById_Existing()
        {
            try
            {
                var item = await client.CreateCargoAsync(new CreateOrUpdateCargoRequest { Cargo = cargoObject});
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = CargoTypesIdExists)]
        public async Task<int> CreateCargoTypesById_Existing()
        {
            try
            {
                var item = await client.CreateCargoTypeAsync(new CreateOrUpdateCargoTypesRequest { CargoType =  cargoTypesObject});
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = ConstraintsIdExists)]
        public async Task<int> CreateConstraintsById_Existing()
        {
            try
            {
                var item = await client.CreateConstraintAsync(new CreateOrUpdateConstraintsRequest { Constraint = constraintsObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = CustomersIdExists)]
        public async Task<int> CreateCustomerById_Existing()
        {
            try
            {
                var item = await client.CreateCustomerAsync(new CreateOrUpdateCustomersRequest { Customer = customersObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = DriverLicenceIdExists)]
        public async Task<int> CreateDriverLicenceById_Existing()
        {
            try
            {
                var item = await client.CreateDriverLicenceAsync(new CreateOrUpdateDriverLicenceRequest { DriverLicence = driverLicenceObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = DriversIdExists)]
        public async Task<int> CreateDriverById_ExistingDriver()
        {
            try
            {
                var item = await client.CreateDriverAsync(new CreateOrUpdateDriversRequest { Driver = driversObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = OrdersIdExists)]
        public async Task<int> CreateOrdersById_Existing()
        {
            try
            {
                var item = await client.CreateOrderAsync(new CreateOrUpdateOrdersRequest { Order = ordersObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = OwnershipsIdExists)]
        public async Task<int> CreateOwnershipsById_Existing()
        {
            try
            {
                var item = await client.CreateOwnershipAsync(new CreateOrUpdateOwnershipsRequest { Ownership = ownershipsObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = RequestsIdExists)]
        public async Task<int> CreateRequestsById_Existing()
        {
            try
            {
                var item = await client.CreateRequestAsync(new CreateOrUpdateRequestObjRequest { Requests = requestsObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = RequisitesIdExists)]
        public async Task<int> CreateRequisitesById_Existing()
        {
            try
            {
                var item = await client.CreateRequisiteAsync(new CreateOrUpdateRequisitesRequest { Requisite = requisitesObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = TransportersIdExists)]
        public async Task<int> CreateTransportersById_Existing()
        {
            try
            {
                var item = await client.CreateTransporterAsync(new CreateOrUpdateTransportersRequest { Transporter = transportersObject});
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = VehicleTypesIdExists)]
        public async Task<int> CreateVehicleTypesById_Existing()
        {
            try
            {
                var item = await client.CreateVehiclesTypeAsync(new CreateOrUpdateVehiclesTypesRequest { VehiclesTypes = vehiclesTypesObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = VehiclesIdExists)]
        public async Task<int> CreateVehicleById_Existing()
        {
            try
            {
                var item = await client.CreateVehicleAsync(new CreateOrUpdateVehiclesRequest { Vehicle = vehiclesObject });
                Assert.Pass($"{item}");
                return await Task.FromResult(item.Id);
            }
            catch (RpcException ex)
            {
                ExceptionsHandler(ex);
                return await Task.FromResult(-1);
            }

        }

        [Test(ExpectedResult = VehicleTransportersTransporterIdExists)]
        public async Task<int> CreateVehicleTransporterById_Existing()
        {
            try
            {
                var item = await client.CreateVehiclesTransporterAsync(new CreateOrUpdateVehiclesTransportersRequest{ VehicleTransporters = vehiclesTransportersObject });
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