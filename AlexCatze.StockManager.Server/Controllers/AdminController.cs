using AlexCatze.StockManager.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace AlexCatze.StockManager.Server.Controllers
{
    public class AdminController : Controller
    {
        private DatabaseContext _context;
        public AdminController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost("Admin/AddStock")]
        public async Task<IActionResult> AddStock(string name, CancellationToken cancellationToken = default)
        {
            _context.Stocks.Add(new Stock { Name = name });
            await _context.SaveChangesAsync();
            return Redirect("/");
        }

        [HttpPost("Admin/AddType")]
        public async Task<IActionResult> AddType(string name, string desc, IFormFile img, CancellationToken cancellationToken = default)
        {
            ThingType type = new ThingType() {Name = name, Description = desc,Image="" };

            try
            {
                if (img!=null&&img.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        img.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);
                        type.Image = s;
                    }
                }
            }catch (Exception ex) { }

            _context.Things.Add(type);
            await _context.SaveChangesAsync();
            return Redirect("/");
        }

        [HttpGet("Admin/RemoveStock")]
        public async Task<IActionResult> RemoveStock(int id, CancellationToken cancellationToken = default)
        {
            Stock stock = await _context.Stocks.FirstOrDefaultAsync(s=>s.Id == id);
            if(stock != null) { _context.Stocks.Remove(stock); }

            await _context.SaveChangesAsync();
            return Redirect("/");
        }

        [HttpGet("Admin/RemoveType")]
        public async Task<IActionResult> RemoveType(int id, CancellationToken cancellationToken = default)
        {
            ThingType type = await _context.Things.FirstOrDefaultAsync(s => s.Id == id);
            if (type != null) { _context.Things.Remove(type); }

            await _context.SaveChangesAsync();
            return Redirect("/");
        }

        [HttpGet("Admin/GetImage")]
        public async Task<IActionResult> GetImage(int id, CancellationToken cancellationToken = default)
        {
            ThingType type = await _context.Things.FirstOrDefaultAsync(s => s.Id == id);
            if(type==null) return NotFound();
            try
            {
                return File(Convert.FromBase64String(type.Image),"image/png");
            }catch(Exception e) { }
            return NotFound();
        }

    }
}
