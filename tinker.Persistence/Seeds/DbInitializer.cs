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
                Console.WriteLine("Seeding Data...");
                foreach (Category c in deserializedCategoryList)
                {
                    await categoryRepository.InsertAsync(c);
                    await categoryRepository.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while seeding the data: ", ex.Message);
                throw;
            }
            Console.WriteLine("Seeding is complete.");
            return true; // seeding is complete.
        }
    }
}
