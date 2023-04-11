using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using tinker.Application.Interfaces.Repositories;
using tinker.Domain.Entities;
using tinker.Persistence.Contexts;
using tinker.Persistence.Repositories;

namespace tinker.Persistence.Seeds
{
    public static class DbInitializer
    {
        public static async Task<bool> seedCategoryData(ICategoryRepository categoryRepository)
        {
            if (categoryRepository.EnsureCreation())
            {
                if (categoryRepository.AnyElements())
                {
                    return true; // already seeded.
                }
            }


            var categoryData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), @"../tinker.Persistence/Seeds/CATEGORY_SEED_DATA.json"));
            var deserializedCategoryList = JsonConvert.DeserializeObject<List<Category>>(categoryData);

            try
            {
                Console.WriteLine("Seeding Category Data...");
                foreach (Category c in deserializedCategoryList)
                {
                    await categoryRepository.InsertAsync(c);
                    await categoryRepository.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while seeding the category data: ", ex.Message);
                throw;
            }
            Console.WriteLine("Seeding the category data is complete.");
            return true; // seeding is complete.
        }
        public static async Task<bool> seedProductData(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            if (productRepository.EnsureCreation())
            {
                if (productRepository.AnyElements())
                {
                    return true; // already seeded.
                }
            }

            var productData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), @"../tinker.Persistence/Seeds/PRODUCT_SEED_DATA.json"));
            var deserializedProductList = JsonConvert.DeserializeObject<List<Product>>(productData);

            try
            {
                Console.WriteLine("Seeding Product Data...");
                foreach (Product p in deserializedProductList)
                {
                    var category = await categoryRepository.GetByIdAsync(p.Category.ID);
                    p.Category = category;

                    await productRepository.InsertAsync(p);
                    await productRepository.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while seeding the product data: ", ex.Message);
                throw;
            }
            Console.WriteLine("Seeding the product data is complete.");
            return true; // seeding is complete.
        }
    }
}
