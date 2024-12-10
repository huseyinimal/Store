using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProduct(bool trackChanges);

        IEnumerable<Product> GetLastestProduct(int n ,bool trackChanges);
        IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);

        IEnumerable<Product> GetShowCaseProducts(bool trackChanges);

        Product? GetProduct(int id, bool trackChanges);

        void CreateProduct(ProductDtoForInsertion productDto);
        void UpdateOneProduct(ProductDtoForUpdate product);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetProductForUpdate(int id, bool trackChanges);
    }
}