using System;
using System.Collections.Generic;
using System.Linq;
using AmaZen.Models;
using AmaZen.Repositories;
using spring21_amazen.Models;
using spring21_amazen.Repositories;

namespace AmaZen.Services
{
    public class WarehouseProductsService
    {
        private readonly WarehouseProductsRepository _warehouseProductsRepo;

        public WarehouseProductsService(WarehousesRepository warehousesRepo, WarehouseProductsRepository warehouseProductsRepo)
        {
            _warehouseProductsRepo = warehouseProductsRepo;
        }

        public WarehouseProductDTO CreateWarehouseProduct(WarehouseProductDTO wp)
        {
            return _warehouseProductsRepo.Create(wp);
        }

        internal WarehouseProductDTO UpdateWarehouseProduct(WarehouseProductDTO wp)
        {
            throw new NotImplementedException();
        }
    }
}