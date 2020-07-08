using EfCodeFirstExercise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstExercise.Controllers
{
    public class ProductsController
    {
        private readonly AppDbContext _context = null;

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> Create(Product product)
        {
            if (product == null) throw new Exception("Product cannot be null");

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Change(Product product, int id)
        {
            if (product == null) throw new Exception("Product cannot be null");
            if (id != product.Id) throw new Exception("Product Id not found");

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task Delete(Product product)
        {
            if (product == null) throw new Exception("Product cannot be null");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var prod = Get(id);
            if (prod == null) throw new Exception("Product not found");
            await Delete(prod.Result);

        }



        public ProductsController()
        {

        }
    }
}
