using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string suppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            //string parts = File.ReadAllText("../../../Datasets/parts.json");
            //string cars = File.ReadAllText("../../../Datasets/cars.json");
            //string customers = File.ReadAllText("../../../Datasets/customers.json");
            //string sales = File.ReadAllText("../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(context, suppliers));
            //Console.WriteLine(ImportParts(context, parts));
            //Console.WriteLine(ImportCars(context, cars));
            //Console.WriteLine(ImportCustomers(context, customers));
            //Console.WriteLine(ImportSales(context, sales));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }


        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IEnumerable<SupplierInputDto> input = JsonConvert
                .DeserializeObject<IEnumerable<SupplierInputDto>>(inputJson);

            Initializer();

            IEnumerable<Supplier> suppliers = mapper.Map<IEnumerable<Supplier>>(input);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IEnumerable<PartInputDto> input = JsonConvert
                .DeserializeObject<IEnumerable<PartInputDto>>(inputJson)
                .Where(x => context.Suppliers.Any(y => y.Id == x.SupplierId));

            Initializer();

            IEnumerable<Part> parts = mapper.Map<IEnumerable<Part>>(input);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<CarsInputDto[]>(inputJson);

            var cars = new List<Car>();
            var carParts = new List<PartCar>();


            foreach (var carDto in carsDto)
            {

                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var part in carDto.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };

                    carParts.Add(carPart);
                }

            }

            context.Cars.AddRange(cars);

            context.PartCars.AddRange(carParts);

            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IEnumerable<CustomerInputDto> input = JsonConvert
                .DeserializeObject<IEnumerable<CustomerInputDto>>(inputJson);

            Initializer();

            IEnumerable<Customer> customers = mapper.Map<IEnumerable<Customer>>(input);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IEnumerable<Sale> sales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(inputJson);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver ? 1 : 0)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .ToArray();

            return JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsFromToyota = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToArray();

            return JsonConvert.SerializeObject(carsFromToyota, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithPartsList = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars
                    .Select(pc => new
                    {
                        pc.Part.Name,
                        Price = pc.Part.Price.ToString("f2")
                    })
                    .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(carsWithPartsList, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1 )
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f2"),
                    price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount = ((s.Car.PartCars.Sum(pc => pc.Part.Price)) * (1 - s.Discount * 0.01m)).ToString("f2")
                })
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        public static void Initializer()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            mapper = new Mapper(config);
        }
    }
}



