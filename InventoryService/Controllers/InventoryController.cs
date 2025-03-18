using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using InventoryService.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InventoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetInventory()
        {
            return await _context.InventoryItems.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<InventoryItem>> AddInventoryItem(InventoryItem item)
        {
            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInventory), new { id = item.Id }, item);
        }
    }
}