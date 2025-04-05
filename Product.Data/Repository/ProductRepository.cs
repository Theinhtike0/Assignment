using Microsoft.Data.SqlClient;
using Product.Data.DataAccess;
using Product.Data.Models.Domain;
using System.Data;

namespace Product.Data.Repository;

 public class ProductRepository : IProductRepository
 {
    private readonly ISqlDataAccess _db;

    public ProductRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<bool> AddAsync(Products product)
    {
        try
        {
            await _db.SaveData("UP_CREATE_PRODUCT", new { product.ProductName, product.Description, product.Price });
            return true;
        }

        catch(Exception ex)
        {
            return (false);        }
    }


    public async Task<bool> UpdateAsync(Products product)
    {
        try
        {
            var parameters = new
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price
            };

            await _db.SaveData("UP_UPDATE_PRODUCT", parameters);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            await _db.SaveData("UP_DELETE_PRODUCT", new { Id = id });
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<Products?> GetByIdAsync(int id)
    {
        IEnumerable<Products> result = await _db.GetData<Products, dynamic>
            ("UP_GET_PRODUCTID", new { Id = id });
        return result.FirstOrDefault();
    }
   
    public async Task<IEnumerable<Products>> GetAllAsync()
    {
        string query = "UP_GET_PRODUCT";
        return await _db.GetData<Products, dynamic>(query, new { });
    }
    
    public async Task<IEnumerable<Products>> GetAllProductsAsync()
    {
        return await _db.GetData<Products, dynamic>("UP_GET_PRODUCT", new { });
    }
}
