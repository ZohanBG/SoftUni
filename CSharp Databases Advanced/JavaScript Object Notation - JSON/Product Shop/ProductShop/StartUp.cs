using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Input;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string usersJson = File.ReadAllText("../../../Datasets/users.json");
            string productsJson = File.ReadAllText("../../../Datasets/products.json");
            string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            string categoriesProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");


            Console.WriteLine(ImportUsers(context, usersJson));
            Console.WriteLine(ImportProducts(context, productsJson));
            Console.WriteLine(ImportCategories(context, categoriesJson));
            Console.WriteLine(ImportCategoryProducts(context, categoriesProductsJson));
            Console.WriteLine(GetCategoriesByProductsCount(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<UserInputDto> users = JsonConvert.DeserializeObject<IEnumerable<UserInputDto>>(inputJson);

            Initializer();

            IEnumerable<User> mappedUsers = mapper.Map<IEnumerable<User>>(users);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<ProductInputDto> products = JsonConvert.DeserializeObject<IEnumerable<ProductInputDto>>(inputJson);

            Initializer();

            IEnumerable<Product> mappedProducts = mapper.Map<IEnumerable<Product>>(products);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryInputDto> categories = JsonConvert
                .DeserializeObject<IEnumerable<CategoryInputDto>>(inputJson)
                .Where(x => !string.IsNullOrEmpty(x.Name));

            Initializer();

            IEnumerable<Category> mappedCategories = mapper.Map<IEnumerable<Category>>(categories);

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryProductInputDto> categoryProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputDto>>(inputJson);

            Initializer();

            IEnumerable<CategoryProduct> mappedCategoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProducts);

            context.CategoryProducts.AddRange(mappedCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedCategoryProducts.Count()}";
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(x => x.ProductsBought.Any(y => y.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Where(y => y.BuyerId != null)
                    .Select(y => new
                    {
                        name = y.Name,
                        price = y.Price,
                        buyerFirstName = y.Buyer.FirstName,
                        buyerLastName = y.Buyer.LastName
                    })
                    .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(soldProducts, Formatting.Indented);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = (c.CategoryProducts.Sum(p => p.Product.Price) / c.CategoryProducts.Count).ToString("f2"),
                    totalRevenue = c.CategoryProducts.Sum(p => p.Product.Price).ToString("f2")
                })
                .OrderByDescending(c => c.productsCount)
                .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var users = context.Users
                .ToArray()
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Count(),
                        products = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                        .ToList()
                    }

                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToList();


            var withUserCount = new
            {
                usersCount = users.Count,
                users,

            };

            var json = JsonConvert.SerializeObject(withUserCount, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });
            return json;
        }


        private static void Initializer()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());

            mapper = new Mapper(mapperConfig);
        }
    }
}
  //{
  //  "category": "Garden",
  //  "productsCount": 23,
  //  "averagePrice": "800.15",
  //  "totalRevenue": "18403.47",
  //},


