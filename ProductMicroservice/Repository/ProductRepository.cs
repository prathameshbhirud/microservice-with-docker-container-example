using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.DBContexts;
using ProductMicroservice.Models;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public void DeleteProduct(int productId)
        {
            var product = _productContext.Products.Find(productId);
            _productContext.Products.Remove(product);
            Save();
        }

        public Product GetProductById(int productId)
        {
            return _productContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productContext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _productContext.Add(product);
            Save();
        }

        public void Save()
        {
            _productContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _productContext.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}
