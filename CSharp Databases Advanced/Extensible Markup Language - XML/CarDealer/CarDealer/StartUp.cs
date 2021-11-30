using AutoMapper;
using CarDealer.Data;
using CarDealer.Dto.Export;
using CarDealer.Dto.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            CarDealerContext contex = new CarDealerContext();
            //contex.Database.EnsureDeleted();
            //contex.Database.EnsureCreated();

            //string suppliers = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string parts = File.ReadAllText("../../../Datasets/parts.xml");
            //string cars = File.ReadAllText("../../../Datasets/cars.xml");
            //string customers = File.ReadAllText("../../../Datasets/customers.xml");
            //string sales = File.ReadAllText("../../../Datasets/sales.xml");

            //Console.WriteLine(ImportSuppliers(contex, suppliers));
            //Console.WriteLine(ImportParts(contex, parts));
            //Console.WriteLine(ImportCars(contex, cars));
            //Console.WriteLine(ImportCustomers(contex, customers));
            //Console.WriteLine(ImportSales(contex, sales));

            Console.WriteLine(GetSalesWithAppliedDiscount(contex));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = GenerateXmlSerializer("Suppliers", typeof(ImportSupplierDto[]));

            ImportSupplierDto[] dtos;

            using (StringReader stringReader = new StringReader(inputXml))
            {
                dtos = (ImportSupplierDto[])xmlSerializer.Deserialize(stringReader);
            }

            Initializer();

            Supplier[] suppliers = mapper.Map<Supplier[]>(dtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = GenerateXmlSerializer("Parts", typeof(ImportPartDto[]));

            ImportPartDto[] dtos;

            using (StringReader stringReader = new StringReader(inputXml))
            {
                dtos = (ImportPartDto[])xmlSerializer.Deserialize(stringReader);
            }

            Initializer();

            Part[] parts = mapper.Map<Part[]>(dtos)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = GenerateXmlSerializer("Cars", typeof(ImportCarDto[]));

            ImportCarDto[] dtos;

            using (StringReader stringReader = new StringReader(inputXml))
            {
                dtos = (ImportCarDto[])xmlSerializer.Deserialize(stringReader);
            }

            ICollection<Car> cars = new HashSet<Car>();
            ICollection<PartCar> carParts = new HashSet<PartCar>();
            foreach (var car in dtos)
            {
                Car newCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };
                cars.Add(newCar);
                foreach (int carPart in car.CarParts.Select(i => i.Id).Distinct())
                {
                    Part part = context.Parts.Find(carPart);

                    if(part == null)
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar()
                    {
                        Car = newCar,
                        PartId = carPart
                    };

                    carParts.Add(partCar);
                }
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = GenerateXmlSerializer("Customers", typeof(ImportCustomerDto[]));

            ImportCustomerDto[] dtos;

            using (StringReader stringReader = new StringReader(inputXml))
            {
                dtos = (ImportCustomerDto[])xmlSerializer.Deserialize(stringReader);
            }

            Initializer();

            Customer[] customers = mapper.Map<Customer[]>(dtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = GenerateXmlSerializer("Sales", typeof(ImportSaleDto[]));

            ImportSaleDto[] dtos;

            using (StringReader stringReader = new StringReader(inputXml))
            {
                dtos = (ImportSaleDto[])xmlSerializer.Deserialize(stringReader);
            }

            Initializer();

            Sale[] sales = mapper.Map<Sale[]>(dtos)
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarDto[] carDtos = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new ExportCarDto { 
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = GenerateXmlSerializer("cars", typeof(ExportCarDto[]));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, carDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportCarDto2[] carDtos = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportCarDto2
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            XmlSerializer xmlSerializer = GenerateXmlSerializer("cars", typeof(ExportCarDto2[]));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, carDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportSupplierDto[] supplierDtos = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            XmlSerializer xmlSerializer = GenerateXmlSerializer("suppliers", typeof(ExportSupplierDto[]));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, supplierDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarWithPartsDto[] carWithPartsDtos = context.Cars
                .Select(c => new ExportCarWithPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                    .Select(p => new ExportPartDto
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToList()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = GenerateXmlSerializer("cars", typeof(ExportCarWithPartsDto[]));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, carWithPartsDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            ExportCustomerDto[] customerDtos = context.Customers
                .Where(c => c.Sales.Count >= 1)         
                .Select(c => new ExportCustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();


            XmlSerializer xmlSerializer = GenerateXmlSerializer("customers", typeof(ExportCustomerDto[]));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, customerDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSaleDto[] saleDtos = context.Sales
                .Select(s => new ExportSaleDto
                {
                    Car = new ExportCarDto3
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount.ToString(CultureInfo.InvariantCulture),
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(p => p.Part.Price).ToString(CultureInfo.InvariantCulture),
                    PriceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) -
                    s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100).ToString(CultureInfo.InvariantCulture)
                })
                .ToArray();

            XmlSerializer xmlSerializer = GenerateXmlSerializer("sales", typeof(ExportSaleDto[]));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, saleDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }





        private static void Initializer()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            mapper = new Mapper(mapperConfig);
        }

        private static XmlSerializer GenerateXmlSerializer(string rootName, Type dtoType)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);

            XmlSerializer xmlSerializer = new XmlSerializer(dtoType, xmlRootAttribute);

            return xmlSerializer;
        }
    }
}