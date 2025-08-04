using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabaty.Core.Entity;

namespace Talabaty.Repository.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext dbContext)
        {
            if(dbContext.Products.Any())
            {
                var TypesData = File.ReadAllText("..\\Talabaty.Repository\\Data\\DataSeed\\types.json");
                var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                if (Types?.Count > 0)
                {
                    foreach (var Type in Types)
                    {
                        await dbContext.Set<ProductType>().AddAsync(Type);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }
            if(dbContext.ProductTypes.Any())
            {
                var ProductsData = File.ReadAllText("..\\Talabaty.Repository\\Data\\DataSeed\\products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                if (Products?.Count > 0)
                {
                    foreach (var Product in Products)
                    {
                        await dbContext.Set<Product>().AddAsync(Product);
                    }
                    await dbContext.SaveChangesAsync();

                }
                if (dbContext.ProductBrands.Any())
            {
                var BrandsData = File.ReadAllText("..\\Talabaty.Repository\\Data\\DataSeed\\brands.json");
                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
                if (Brands?.Count > 0)
                {
                    foreach (var Brand in Brands)
                    {
                        await dbContext.Set<ProductBrand>().AddAsync(Brand);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }
            }
        }
    }
}
