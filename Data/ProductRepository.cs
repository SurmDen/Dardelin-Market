using DardelinMarket.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DardelinMarket.Data
{
    public class ProductRepository : IProductRepository
    {
        private DataContext context;

        public ProductRepository(DataContext context)
        {
            this.context = context;
        }

        public void CreateCategory(Category category)
        {
            context.Categories.Add(category);

            context.SaveChanges();
        }

        public void CreateProduct(Product product)
        {
            List<Product> products = context.Products.ToList();

            products.Add(product);

            context.Products.AddRange(products);

            context.SaveChanges();
        }

        public void DeleteCategory(long id)
        {
            Category category = context.Categories.First(c => c.Id == id);

            context.Categories.Remove(category);

            context.SaveChanges();
        }

        public void DeleteProduct(long id)
        {
            Product product = context.Products.First(c => c.Id == id);

            context.Products.Remove(product);

            context.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            IEnumerable<Category> categories = context.Categories.Include(c=>c.Products);

            if (categories.Count() != 0)
            {
                foreach (Category category in categories)
                {
                    if (category.Products != null)
                    {
                        foreach (Product product in category.Products)
                        {
                            product.Category = null;
                        }
                    }
                }
            }

            return categories;
        }

        public Category GetCategoryById(long id)
        {
            Category category =  context.Categories.Include(c=>c.Products).First(c => c.Id == id);

            foreach (var product in category.Products)
            {
                product.Category = null;
            }

            return category;
        }

        public Product GetProductById(long id)
        {
            return context.Products.First(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        public void UpdateCategory(Category category)
        {
            context.Categories.Update(category);

            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);

            context.SaveChanges();
        }
    }
}
