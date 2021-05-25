using System;
using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmaZen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _productsService;

        public ProductsController(ProductsService ps)
        {
            _productsService = ps;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            try
            {
                List<Product> products = _productsService.GetAll();
                return Ok(products);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            try
            {
                Product found = _productsService.GetById(id);
                return Ok(found);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Product> Create([FromBody] Product data)
        {
            try
            {
                Product product = _productsService.Create(data);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Product> Update([FromBody] Product data)
        {
            try
            {
                Product update = _productsService.Update(data);
                return Ok(update);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}