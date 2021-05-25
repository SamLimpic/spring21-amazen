using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using spring21_amazen.Models;

namespace spring21_amazen.Repositories
{
    public class WarehouseProductsRepository
    {
        private readonly IDbConnection _db;

        public WarehouseProductsRepository(IDbConnection db)
        {
            _db = db;
        }

        public WarehouseProductDTO Create(WarehouseProductDTO data)
        {
            string sql = @"
            INSERT INTO warehouse_products
            (warehouseId, productId)
            VALUES
            (@WarehouseId, @ProductId);
            SELECT LAST_INSERT_ID();
            ";
            data.Id = _db.ExecuteScalar<int>(sql, data);
            return data;
        }

        internal List<WarehouseProductView> GetProductsByWarehouseId(int id)
        {
            string sql = @"
            SELECT
            p.*,
            w.location,
            w.id as warehouseProductId,
            wp.productId,
            wp.warehouseId
            FROM
            warehouse_products wp
            JOIN warehouses w ON w.id = wp.warehouseId
            JOIN products p ON p.id = wp.productId
            WHERE
            wp.warehouseId = @Id
            ";
            return _db.Query<WarehouseProductView>(sql, new { id }).ToList();
        }
    }
}