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

        public const int CargoIdExists = 777;
        public const int CargoConstraintsCargoIdExists = 777;
        public const int CargoConstraintsConstraintIdExists = 777;
        public const int CargoTypesIdExists = 777;
        public const int ConstraintsIdExists = 777;
        public const int CustomersIdExists = 777;
        public const int DriverLicenceIdExists = 777;
        public const int DriversIdExists = 777;
        public const int OrdersIdExists = 777;
        public const int OwnershipsIdExists = 777;
        public const int RequestsIdExists = 777;
        public const int RequisitesIdExists = 777;
        public const int TransportersIdExists = 777;
        public const int VehicleTypesIdExists = 777;
        public const int VehiclesIdExists = 777;
        public const int VehicleTransportersTransporterIdExists = 777;
        public const int VehicleTransportersVehicleIdExists = 777;
        public const int RouteObjectIdExists = 777;
        public const int RouteActionIdExists = 777;
        public const int RoleIdExists = 777;
        public const int RequisiteTypeIdExists = 777;
        public const string LoginExists = "abobusprimadeultima";

        public static CargoObject cargoObject = new CargoObject()
        {
            Id = 777,
            Constraints = "Ограничение по температуре",
            Name = "Name",
            Price = 77100,
            Type = 1,
            Volume = 1,
            Weight = 1,
            CargoType = new CargoTypesObject() { Id = 777},
        };
        public static CargoTypesObject cargoTypesObject = new CargoTypesObject()
        {
            Id = 777,
            Name = "Морепродукты"
        };
        public static DriverLicenceObject driverLicenceObject = new DriverLicenceObject()
        {
            Id = 777,
            Date = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime().ToUniversalTime()),
            Number = 7777,
            Series = 6666
        };
        public static DriversObject driversObject = new DriversObject()
        {
            Id = 777,
            Licence = new DriverLicenceObject { Id = 777},
            Name = "Name",
            Patronymic = "Patr",
            Sanitation = true,
            Surname = "Surn",
        };
        public static RequestsObject requestsObject = new RequestsObject()
        {
            Id = 777,
            Conditions = true,
            Price = 1,
            Vehicle = new VehiclesObject { Id = 1 },
            Cargo = new CargoObject { Id = 777 },
            CreationDate = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime()),
            Documents = true,
            IsFinished = true,
            Driver = new DriversObject { Id = 777 },
            CustomerReq = new RequisitesObject { Id = 777},
            Routes = null,
            TransporterReq = new RequisitesObject { Id = 1},
        };
        public static RequisitesObject requisitesObject = new RequisitesObject()
        {
            Id = 777,
            Name = "ООО \"МясоКомбинат\"",
            Ceo = "Иван Васильевич Прокопенко",
            Inn = "123456",
            LegalAddress = "125080, г. Москва, ул. Березовая, 19, оф. 53",
            Pts = 77731
        };


        public static RequisiteTypeObject requisiteTypeObject = new RequisiteTypeObject()
        {
            Id = 777,
            Name = "УП",
        };

        public static RolesObject rolesObject = new RolesObject()
        {
            Id = 777,
            Name = "Поставщик"
        };

        public static VehiclesTypesObject vehiclesTypesObject = new VehiclesTypesObject()
        {
            Id = 777,
            Name = "1"
        };

        public static VehiclesObject vehiclesObject = new VehiclesObject()
        {
            Id = 777,
            Number = "ABC5531",
            Owner = new RequisitesObject { Id = 1},
            Type = new VehiclesTypesObject { Id = 1},
        };
        public static LoginObject loginObject = new LoginObject()
        {
            Login = "alex",
            Password = "3C9909AFEC25354D551DAE21590BB26E38D53F2173B8D3DC3EEE4C047E7AB1C1EB8B85103E3BE7BA613B31BB5C9C36214DC9F14A42FD7A2FDB84856BCA5C44C2",
        };

        public static RouteObject routeObject = new RouteObject()
        {
            Id = 777,
            Action = new RouteActionsObject { Id = 777 },
            ActionDate = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime()),
            Address = "951115, Воронежская область, город Коломна, пер. Косиора, 07",
        };

        public static RouteActionsObject routeActionsObject = new RouteActionsObject()
        {
            Id = 777,
            Action = "Загрузка сбоку",
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
        public string address { get; set; } = "http://localhost:8008";
    }
}
