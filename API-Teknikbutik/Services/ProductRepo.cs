using API_Teknikbutiken_Models;
using API_Teknikbutik.Data;
using Microsoft.EntityFrameworkCore;

namespace API_Teknikbutik.Services
{
    public class ProductRepo : ITeknikButik<Product>
    {
        private AppDbContext _appContext;
        public ProductRepo(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Product> Add(Product newEntity)
        {
           var result =  await _appContext.Products.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> Delete(int id)
        {
           var result = await _appContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (result != null)
            {
                _appContext.Products.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _appContext.Products.ToListAsync();
        }

        public async Task<Product> GetSingel(int id)
        {
            return await _appContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<Product> Update(Product entity)
        {
            var result = await _appContext.Products.FirstOrDefaultAsync
                (p => p.ProductId == entity.ProductId);
            if(result != null)
            {
                result.ProductName = entity.ProductName;
                result.Price = entity.Price;
                result.Category = entity.Category;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
