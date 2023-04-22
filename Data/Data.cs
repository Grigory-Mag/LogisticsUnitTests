using ApiService;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsUnitTests.Data
{
    public static class Data
    {
        public static UserService.UserServiceClient client = new UserService.UserServiceClient(GrpcChannel.ForAddress(GetDbConnection()));

        public const int CargoIdExists = 1;
        public const int CargoConstraintsCargoIdExists = 1;
        public const int CargoConstraintsConstraintIdExists = 1;
        public const int CargoTypesIdExists = 1;
        public const int ConstraintsIdExists = 1;
        public const int CustomersIdExists = 1;
        public const int DriverLicenceIdExists = 1;
        public const int DriversIdExists = 1;
        public const int OrdersIdExists = 1;
        public const int OwnershipsIdExists = 1;
        public const int RequestsIdExists = 1;
        public const int RequisitesIdExists = 1;
        public const int TransportersIdExists = 1;
        public const int VehicleTypesIdExists = 1;
        public const int VehiclesIdExists = 1;
        public const int VehicleTransportersTransporterIdExists = 1;
        public const int VehicleTransportersVehicleIdExists = 1;
        public const string LoginExists = "abobusprimadeultima";

        public static CargoObject cargoObject = new CargoObject()
        {
            Id = 1,
            Constraints = 1,
            Name = "Name",
            Price = 1,
            Type = 1,
            Volume = 1,
            Weight = 1,
        };
        public static CargoConstraintsObject cargoConstraintsObject = new CargoConstraintsObject()
        {
            IdCargo = 1,
            IdConstraint = 1,
        };
        public static CargoTypesObject cargoTypesObject = new CargoTypesObject()
        {
            Id = 1,
            Name = "Name"
        };
        public static ConstraintsObject constraintsObject = new ConstraintsObject()
        {
            Id = 1,
            Desc = "Desc"
        };
        public static CustomersObject customersObject = new CustomersObject()
        {
            Id = 1,
            Cargo = 1,
            Requisite = 1
        };
        public static DriverLicenceObject driverLicenceObject = new DriverLicenceObject()
        {
            Id = 1,
            Date = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime().ToUniversalTime()),
            Number = 1234,
            Series = 1241
        };
        public static DriversObject driversObject = new DriversObject()
        {
            Id = 1,
            Licence = 1,
            Name = "Name",
            Patronymic = "Patr",
            Sanitation = true,
            Surname = "Surn"
        };
        public static OrdersObject ordersObject = new OrdersObject()
        {
            Id = 1,
            Cargo = 1,
            Date = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime())
        };
        public static OwnershipsObject ownershipsObject = new OwnershipsObject()
        {
            Id = 1,
            Name = "Name"
        };
        public static RequestsObject requestsObject = new RequestsObject()
        {
            Id = 1,
            Conditions = true,
            Order = 1,
            Price = 1,
            Vehicle = 1
        };
        public static RequisitesObject requisitesObject = new RequisitesObject()
        {
            Id = 1,
            Ceo = "ООО \"Рога и копыта\"",
            Inn = "123456",
            LegalAddress = "1",
            Ownership = 1,
            Pts = 1
        };
        public static TransportersObject transportersObject = new TransportersObject()
        {
            Id = 1,
            Name = "1"
        };
        public static VehiclesTypesObject vehiclesTypesObject = new VehiclesTypesObject()
        {
            Id = 1,
            Name = "1"
        };
        public static VehiclesObject vehiclesObject = new VehiclesObject()
        {
            Id = 1,
            Driver = 1,
            Number = "12314",
            Owner = 1,
            Type = 1
        };
        public static VehiclesTransportersObject vehiclesTransportersObject = new VehiclesTransportersObject()
        {
            Transporter = 1,
            Vehicle = 1
        };
        public static LoginObject loginObject = new LoginObject()
        {
            Login = "clown",
            Password = "gigachad"
        };

        private static string GetDbConnection()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("file.json", optional: true, reloadOnChange: true);

            var connection = builder.Build().GetSection("Connection").Value; ;
            
            return connection;
        }
    }

    public class Connection
    {
        public string address { get; set; } = "http://localhost:8088";
    }
}
