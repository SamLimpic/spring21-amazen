using System;
using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
    public class ProductsService
    {
        private readonly ProductsRepository _productsRepository;

        public ProductsService(ProductsRepository ps)
        {
            _productsRepository = ps;
        }

        public List<Product> GetAll()
        {
            return _productsRepository.GetAll();
        }

        internal Product GetById(int id)
        {
            Product product = _productsRepository.GetById(id);
            if (product == null)
            {
                throw new Exception("Invalid Id");
            }
            return product;
        }

        internal Product Create(Product data)
        {
            return _productsRepository.Create(data);
        }

        internal Product Update(Product data)
        {
            if (_productsRepository.Update(data))
            {
                return data;
            }
            throw new Exception("Something has gone wrong...");
        }
    }
}