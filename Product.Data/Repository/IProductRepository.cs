using Product.Data.Models.Domain;

namespace Product.Data.Repository
{
    public interface IProductRepository
    {
        Task<bool> AddAsync(Products product);

        Task<bool> UpdateAsync(Products product);

        Task<bool> DeleteAsync(int id);

        Task<Products> GetByIdAsync(int id);

        Task<IEnumerable<Products>> GetAllAsync();

        Task<IEnumerable<Products>> GetAllProductsAsync();
    }
}