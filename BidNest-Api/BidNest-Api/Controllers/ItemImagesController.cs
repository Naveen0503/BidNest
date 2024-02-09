using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BidNest_Library.Models;

namespace BidNest_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemImagesController : ControllerBase
    {
        private readonly BidNestContext _context;

        public ItemImagesController(BidNestContext context)
        {
            _context = context;
        }

        // GET: api/ItemImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemImage>>> GetItemImages()
        {
            return await _context.ItemImages.ToListAsync();
        }

        // GET: api/ItemImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemImage>> GetItemImage(int id)
        {
            var itemImage = await _context.ItemImages.FindAsync(id);

            if (itemImage == null)
            {
                return NotFound();
            }

            return itemImage;
        }

        // PUT: api/ItemImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemImage(int id, ItemImage itemImage)
        {
            if (id != itemImage.ImageId)
            {
                return BadRequest();
            }

            _context.Entry(itemImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ItemImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemImage>> PostItemImage(ItemImage itemImage)
        {
            _context.ItemImages.Add(itemImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemImage", new { id = itemImage.ImageId }, itemImage);
        }

        // DELETE: api/ItemImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemImage(int id)
        {
            var itemImage = await _context.ItemImages.FindAsync(id);
            if (itemImage == null)
            {
                return NotFound();
            }

            _context.ItemImages.Remove(itemImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemImageExists(int id)
        {
            return _context.ItemImages.Any(e => e.ImageId == id);
        }
    }
}
