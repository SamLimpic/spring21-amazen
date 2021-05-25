using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Services;
using Microsoft.AspNetCore.Mvc;
using spring21_amazen.Models;

namespace AmaZen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseProductsController : ControllerBase
    {
        private readonly WarehouseProductsService _warehouseProductsService;

        public WarehouseProductsController(WarehouseProductsService ws)
        {
            _warehouseProductsService = ws;
        }

        [HttpPost]
        public ActionResult<WarehouseProductDTO> CreateWarehouseProduct([FromBody] WarehouseProductDTO wp)
        {
            try
            {
                WarehouseProductDTO newProduct = _warehouseProductsService.CreateWarehouseProduct(wp);
                return Ok(newProduct);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<WarehouseProductDTO> UpdateWarehouseProduct([FromBody] WarehouseProductDTO wp)
        {
            try
            {
                WarehouseProductDTO update = _warehouseProductsService.UpdateWarehouseProduct(wp);
                return Ok(update);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}