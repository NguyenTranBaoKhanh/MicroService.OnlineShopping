using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Mobile.DbContexts;
using OnlineShopping.Mobile.Models;

namespace OnlineShopping.Mobile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MobileProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public MobileProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Create(MobileProduct product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Mobiles.Add(product);
                _dbContext.SaveChanges();
                return Ok(product);
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<MobileProduct> mobileProducts = _dbContext.Mobiles.ToList();
            return Ok(mobileProducts);
        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            MobileProduct mobileProduct = _dbContext.Mobiles.Find(id);
            return Ok(mobileProduct);
        }

        [HttpPut]
        public IActionResult Update(MobileProduct product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Mobiles.Update(product);
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
            MobileProduct mobileProduct = _dbContext.Mobiles.Find(id);
            _dbContext.Mobiles.Remove(mobileProduct);
            _dbContext.SaveChanges();

            return Ok(mobileProduct);
        }
    }
}