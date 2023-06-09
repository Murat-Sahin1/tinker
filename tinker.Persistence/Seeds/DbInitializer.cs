﻿using Microsoft.EntityFrameworkCore;
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

            var categories = new List<Category>
            {
            new Category{Name="Reinforcement Learning",Description="Machine learning training method based on rewarding desired behaviors and/or punishing undesired ones."},
            new Category{Name="Computer Vision",Description="Machine learning models that take image as the input."},
            new Category{Name="Language Processeing",Description="Machine learning models that take image as the input in general."},
            new Category{Name="Medical Imaging",Description="Machine learning models that revolves around medicine."},
            new Category{Name="Game AI",Description="Models for games."},
            new Category{Name="Customer Segmentation",Description="Differ your customers based on their demands."},
            new Category{Name="Others",Description="Other software applications."},
            };

            try
            {
                await categoryRepository.InsertRangeAsync(categories);
                await categoryRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while seeding the category data: ", ex.Message);
                throw;
            }


            return true;
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

            var products = new List<Product>
            {
            new Product
            {
                Name="Cat and Dog Identificator",
                Description="A model that simply detects dogs and cats and identifies them.",
                ModelID = "15bed8ec-54c9-44db-a50f-d577217d5014",
                Images = new List<Image>{ new Image { Url = "https://flxt.tmsimg.com/assets/p22041592_i_v13_aa.jpg"}},
                Sold = 14,
                Price = 1831,
                CategoryId = 2,
                ProductStatus = Domain.Enums.ProductStatus.Active,
            },
            new Product
            {
                Name="Pathfinding Model",
                Description="Simple chat bot",
                ModelID = "9b59ecb4-3756-4d78-8352-aa07ded0571f",
                Images = new List<Image>{ new Image { Url = "https://decider.com/wp-content/uploads/2022/05/LOVE-DEATH-AND-ROBOTS-SEASON-3-NETFLIX-REVIEW.jpg?quality=75&strip=all" } },
                Sold = 14,
                Price = 1831,
                CategoryId = 5,
                ProductStatus = Domain.Enums.ProductStatus.Active,
            },
            new Product
            {
                Name="Number Identification",
                Description="Differ the numbers",
                ModelID = "7f305904-4454-4083-8f54-55744f1c79cd",
                Images = new List<Image>{ new Image { Url = "https://decider.com/wp-content/uploads/2022/05/LOVE-DEATH-AND-ROBOTS-SEASON-3-NETFLIX-REVIEW.jpg?quality=75&strip=all" } },
                Sold = 14,
                Price = 1831,
                CategoryId = 2,
                ProductStatus = Domain.Enums.ProductStatus.Active,
            },
            new Product
            {
                Name="Chat Bot",
                Description="Simple chat bot",
                ModelID = "2891b90e-0698-4c92-8263-e671f101a13e",
                Images = new List<Image>{ new Image { Url = "https://decider.com/wp-content/uploads/2022/05/LOVE-DEATH-AND-ROBOTS-SEASON-3-NETFLIX-REVIEW.jpg?quality=75&strip=all" } },
                Sold = 14,
                Price = 1831,
                CategoryId = 3,
                ProductStatus = Domain.Enums.ProductStatus.Active,
            },
            new Product
            {
                Name="Blood Cell Identification",
                Description="Simple chat bot",
                ModelID = "9949f73c-921a-41c7-9665-e1eba160a4e1",
                Images = new List<Image>{ new Image { Url = "https://decider.com/wp-content/uploads/2022/05/LOVE-DEATH-AND-ROBOTS-SEASON-3-NETFLIX-REVIEW.jpg?quality=75&strip=all" } },
                Sold = 393,
                Price = 1831,
                CategoryId = 4,
                ProductStatus = Domain.Enums.ProductStatus.Active,
            },
            new Product
            {
                Name="Race Game Ai",
                Description="Getting better at racing per generation, ",
                ModelID = "dc538890-ef57-4275-808d-eba462105622",
                Images = new List<Image>{ new Image { Url = "https://decider.com/wp-content/uploads/2022/05/LOVE-DEATH-AND-ROBOTS-SEASON-3-NETFLIX-REVIEW.jpg?quality=75&strip=all" } },
                Sold = 393,
                Price = 1831,
                CategoryId = 1,
                ProductStatus = Domain.Enums.ProductStatus.Active,
            },
            };

            try
            {
                Console.WriteLine("Seeding Product Data...");
                foreach (Product p in products)
                {
                    var category = await categoryRepository.GetByIdAsync(p.CategoryId);
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
