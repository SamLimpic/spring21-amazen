using System;
using System.Collections.Generic;
using System.Linq;
using AmaZen.Models;
using AmaZen.Repositories;
using spring21_amazen.Models;
using spring21_amazen.Repositories;

namespace AmaZen.Services
{
    public class WarehousesService
    {
        private readonly WarehousesRepository _warehousesRepo;
        private readonly WarehouseProductsRepository _warehouseProductsRepo;

        public WarehousesService(WarehousesRepository warehousesRepo, WarehouseProductsRepository warehouseProductsRepo)
        {
            _warehousesRepo = warehousesRepo;
            _warehouseProductsRepo = warehouseProductsRepo;
        }

        public List<Warehouse> GetAll()
        {
            return _warehousesRepo.GetAll();
        }

        internal List<WarehouseProductView> GetProducts(int id)
        {
            return _warehouseProductsRepo.GetProductsByWarehouseId(id);
        }
    }
}