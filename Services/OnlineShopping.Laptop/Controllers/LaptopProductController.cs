using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Laptop.DbContexts;
using OnlineShopping.Laptop.Models;

namespace OnlineShopping.Laptop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaptopProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public LaptopProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Create(LaptopProduct product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Laptops.Add(product);
                _dbContext.SaveChanges();
                return Ok(product);
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<LaptopProduct> laptopProducts = _dbContext.Laptops.ToList();
            return Ok(laptopProducts);
        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            LaptopProduct laptopProduct = _dbContext.Laptops.Find(id);
            return Ok(laptopProduct);
        }

        [HttpPut]
        public IActionResult Update(LaptopProduct product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Laptops.Update(product);
                _dbContext.SaveChanges();
                return Ok(product);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            LaptopProduct laptopProduct = _dbContext.Laptops.Find(id);
            _dbContext.Laptops.Remove(laptopProduct);
            _dbContext.SaveChanges();

            return Ok(laptopProduct);
        }
    }
}