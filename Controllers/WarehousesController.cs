using System;
using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Services;
using Microsoft.AspNetCore.Mvc;
using spring21_amazen.Models;

namespace AmaZen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehousesController : ControllerBase
    {
        private readonly WarehousesService _warehousesService;

        public WarehousesController(WarehousesService ws)
        {
            _warehousesService = ws;
        }

        [HttpGet]
        public ActionResult<List<Warehouse>> GetAll()
        {
            try
            {
                List<Warehouse> warehouses = _warehousesService.GetAll();
                return Ok(warehouses);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/products")]
        public ActionResult<List<WarehouseProductView>> GetWarehouseProducts(int id)
        {
            try
            {
                List<WarehouseProductView> products = _warehousesService.GetProducts(id);
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}