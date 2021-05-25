using System.Collections.Generic;
using System.Data;
using System.Linq;
using AmaZen.Interfaces;
using AmaZen.Models;
using Dapper;

namespace AmaZen.Repositories
{
    public class ProductsRepository : IRepo<Product>
    {
        private readonly IDbConnection _db;

        public ProductsRepository(IDbConnection db)
        {
            _db = db;
        }

        public Product Create(Product data)
        {
            string sql = @"
            INSERT INTO products
            (name, description, sku, price)
            VALUES
            (@Name, @Description, @Sku, @Price)
            SELECT LAST_INSERT_ID()
            ";
            data.Id = _db.ExecuteScalar<int>(sql, data);
            return data;
        }

        public List<Product> GetAll()
        {
            string sql = "SELECT * FROM products";
            return _db.Query<Product>(sql).ToList();
        }

        public Product GetById(int id)
        {
            string sql = "SELECT * FROM products WHERE id = @id";
            return _db.QueryFirstOrDefault<Product>(sql, new { id });
        }

        public bool Update(Product data)
        {
            string sql = @"
            UPDATE products
            SET
                name = @Name,
                description = @Description,
                sku = @Sku,
                price = @Price
            WHERE id = @id
            ";
            int affectedRows = _db.Execute(sql, data);
            return affectedRows == 1;
        }
    }
}