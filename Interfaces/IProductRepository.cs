using DardelinMarket.Data;

namespace DardelinMarket.Interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();

        public IEnumerable<Category> GetCategories();

        public Product GetProductById(long id);

        public Category GetCategoryById(long id);

        public void CreateProduct(Product product);

        public void CreateCategory(Category category);

        public void UpdateProduct(Product product);

        public void UpdateCategory(Category category);

        public void DeleteProduct(long id);

        public void DeleteCategory(long id);
    }
}
