using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BidNest_Library.Models;
using BidNest_Library.Helpers;
using BidNest_Library.Interfaces;

namespace BidNest_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemImagesController : ControllerBase
    {
        private readonly BidNestContext _context;
        private readonly IServices _services;

        public ItemImagesController(BidNestContext context,IServices services)
        {
            _context = context;
            _services = services;
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

        [HttpPost("upload-images")]
        public async Task<ActionResult<List<ItemImage>>> PostItemImages(List<IFormFile> images,int id)
        {
            List<ItemImage> uploadedImages = new List<ItemImage>();

            try
            {
                foreach (var imageFile in images)
                {
                    var imageData = await _services.SaveImageDataAsync(imageFile);

                    var itemImage = new ItemImage
                    {
                        ItemId = id,
                        ImageData = imageData
                    };

                    _context.ItemImages.Add(itemImage);
                    uploadedImages.Add(itemImage);
                }
                await _context.SaveChangesAsync();
               return Ok(uploadedImages);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error uploading images", Error = ex.Message ,innerexception = ex.InnerException});
            }
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
