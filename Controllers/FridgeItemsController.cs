using Microsoft.AspNetCore.Mvc;
using FridgeAPI.Data;
using FridgeAPI.Models;

namespace FridgeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FridgeItemsController : ControllerBase
    {
        private readonly FridgeContext _context;

        public FridgeItemsController(FridgeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FridgeItem>> GetAll()
        {
            return Ok(_context.FridgeItems.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<FridgeItem> GetById(int id)
        {
            var item = _context.FridgeItems.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public ActionResult Create(FridgeItem item)
        {
            _context.FridgeItems.Add(item);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, FridgeItem updatedItem)
        {
            var item = _context.FridgeItems.Find(id);
            if (item == null) return NotFound();

            item.Name = updatedItem.Name;
            item.ExpiryDate = updatedItem.ExpiryDate;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var item = _context.FridgeItems.Find(id);
            if (item == null) return NotFound();

            _context.FridgeItems.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
