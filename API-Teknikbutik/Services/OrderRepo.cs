using API_Teknikbutik.Data;
using API_Teknikbutiken_Models;
using Microsoft.EntityFrameworkCore;

namespace API_Teknikbutik.Services
{
    public class OrderRepo : ITeknikButik<Order>
    {
        private AppDbContext _appDbContext;
        public OrderRepo(AppDbContext appDbContex)
        {
          _appDbContext = appDbContex;
        }

        public async Task<Order> Add(Order newEntity)
        {
            var result =  await _appDbContext.Orders.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Order> Delete(int id)
        {
            var result = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
            if (result != null)
            {
                _appDbContext.Orders.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetSingel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
