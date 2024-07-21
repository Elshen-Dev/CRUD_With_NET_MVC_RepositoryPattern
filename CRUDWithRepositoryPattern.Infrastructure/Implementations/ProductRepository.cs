using CRUDWithRepositoryPattern.Core;
using CRUDWithRepositoryPattern.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithRepositoryPattern.Infrastructure.Implementations
{
    public class ProductRepository : IProductRepository
    {
        #region DbContext
        private readonly MyAppDbContext _mydbContext;
        public ProductRepository(MyAppDbContext mydbContext)
        {
            _mydbContext = mydbContext;
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _mydbContext.Products.ToListAsync();
            return products;
        }
        #endregion

        #region GetById
        public async Task<Product> GetById(int id)
        {
            return await _mydbContext.Products.FindAsync(id);
        }
        #endregion

        #region Add
        public async Task Add(Product model)
        {
            await _mydbContext.Products.AddAsync(model);
            await Save();
        }
        #endregion

        #region Update
        public async Task Update(Product model)
        {
            var product = await _mydbContext.Products.FindAsync(model.Id);
            if (product != null)
            {
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.Qty = model.Qty;
                await Save();
            }
        }
        #endregion

        #region Delete
        public async Task Delete(int id)
        {
            var product = await _mydbContext.Products.FindAsync(id);
            if (product != null)
            {
                _mydbContext.Products.Remove(product);
                await Save();
            }
        }

        #endregion

        #region Save
        private async Task Save()
        {
            await _mydbContext.SaveChangesAsync();
        }

        #endregion

    }
}
