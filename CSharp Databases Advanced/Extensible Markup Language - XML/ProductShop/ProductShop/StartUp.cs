using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext contex = new ProductShopContext();
            //contex.Database.EnsureDeleted();
            //contex.Database.EnsureCreated();

            //string usersInput = File.ReadAllText("../../../Datasets/users.xml");
            //string productsInput = File.ReadAllText("../../../Datasets/products.xml");
            //string categoriesInput = File.ReadAllText("../../../Datasets/categories.xml");
            //string categoriesProductsInput = File.ReadAllText("../../../Datasets/categories-products.xml");

            //Console.WriteLine(ImportUsers(contex, usersInput));
            //Console.WriteLine(ImportProducts(contex, productsInput));
            //Console.WriteLine(ImportCategories(contex, categoriesInput));
            //Console.WriteLine(ImportCategoryProducts(contex, categoriesProductsInput));

            Console.WriteLine(GetUsersWithProducts(contex));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Users");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), xmlRootAttribute);

            ImportUserDto[] dtos;

            using (StringReader stringReader = new StringReader(inputXml))
            {
                dtos = (ImportUserDto[])xmlSerializer.Deserialize(stringReader);
            }

            Initializer();

            User[] users = mapper.Map<User[]>(dtos);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Products");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), xmlRootAttribute);

            ImportProductDto[] dtos;

            using (StringReader stringReader = new StringReader(inputXml))
            {
                dtos = (ImportProductDto[])xmlSerializer.Deserialize(stringReader);
            }

            Initializer();

            Product[] products = mapper.Map<Product[]>(dtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Categories");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), xmlRootAttribute);

            ImportCategoryDto[] dtos;

            using (StringReader stringReader = new StringReader(inputXml))
            {
                dtos = (ImportCategoryDto[])xmlSerializer.Deserialize(stringReader);
            }

            dtos = dtos.Where(x => x.Name != null).ToArray();

            Initializer();

            Category[] categories = mapper.Map<Category[]>(dtos);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("CategoryProducts");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), xmlRootAttribute);

            ImportCategoryProductDto[] dtos;

            using (StringReader stringReader = new StringReader(inputXml))
            {
                dtos = (ImportCategoryProductDto[])xmlSerializer.Deserialize(stringReader);
            }

            dtos = dtos.Where(x => context.Categories.Any(z => z.Id == int.Parse(x.CategoryId))
                                  && context.Products.Any(z => z.Id == int.Parse(x.ProductId)))
                                                     .ToArray();

            Initializer();

            CategoryProduct[] categoryProducts = mapper.Map<CategoryProduct[]>(dtos);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            OutputProductDto[] products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new OutputProductDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName

                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = GenerateXmlSerializer("Products", typeof(OutputProductDto[]));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, products, namespaces);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            OutputCategoryByProductDto[] categories = context.Categories
                .Select(x => new OutputCategoryByProductDto
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count.ToString(CultureInfo.InvariantCulture),
                    AveragePrice = x.CategoryProducts.Average(z => z.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(z => z.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            XmlSerializer xmlSerializer = GenerateXmlSerializer("Categories", typeof(OutputCategoryByProductDto[]));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, categories, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUsersSoldProductsDto[] users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new ExportUsersSoldProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Select(p => new ExportProductDto()
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToList()
                })
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = GenerateXmlSerializer("Users", typeof(ExportUsersSoldProductsDto[]));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, users, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .ToList()
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new ExportUserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age.ToString(),
                    SoldProducts = new ExportSoldProductsDto()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                        .Select(z => new ExportProductDto
                        {
                            Name = z.Name,
                            Price = z.Price

                        })
                        .OrderByDescending(x => x.Price)
                        .ToList()
                    }
                })
                .ToList();

            ExportMainDto exportDto = new ExportMainDto
            {
                Count = users.Count,
                ExportUsers = users.Take(10).ToList()
            };

            StringBuilder sb = new StringBuilder();
            using (StringWriter stringWriter = new StringWriter(sb))
            {
                XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportMainDto), xmlRoot);
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);
                xmlSerializer.Serialize(stringWriter, exportDto, xmlSerializerNamespaces);
            }
            return sb.ToString().TrimEnd();

        }

        private static XmlSerializer GenerateXmlSerializer(string rootName , Type dtoType)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootName);

            XmlSerializer xmlSerializer = new XmlSerializer(dtoType, xmlRootAttribute);

            return xmlSerializer;
        }

        private static void Initializer()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());

            mapper = new Mapper(mapperConfig);
        }

    }
}