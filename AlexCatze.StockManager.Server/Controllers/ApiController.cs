using AlexCatze.StockManager.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlexCatze.StockManager.Server.Controllers
{
    public class ApiController : Controller
    {
        private DatabaseContext _context;
        public ApiController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost("Api/AddThing")]
        public async Task<IActionResult> AddThing(CancellationToken cancellationToken = default)
        {
            string body;
            using (var reader = new StreamReader(Request.Body))
                body = await reader.ReadToEndAsync();
            ThingType thing;
            try
            {
                thing = JsonSerializer.Deserialize<ThingType>(body);
            } catch (Exception ex) { return BadRequest(); }

            var context = new ValidationContext(thing);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(thing, context, results, true))
            {
                return BadRequest();
            }

            var exist = await _context.Things.Where(t => t.Id == thing.Id).FirstOrDefaultAsync();
            if (exist != null)
            _context.Things.Remove(exist);
            _context.Things.Add(thing);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Api/GetThings")]
        public async Task<IActionResult> GetThings(CancellationToken cancellationToken = default)
        {
            var things = await _context.Things.AsNoTracking().ToListAsync();
            return Ok(JsonSerializer.Serialize(things));
        }

        [HttpPost("Api/GetThing")]
        public async Task<IActionResult> GetThing(CancellationToken cancellationToken = default)
        {
            string body;
            using (var reader = new StreamReader(Request.Body))
                body = await reader.ReadToEndAsync();
            ThingType thing;
            try
            {
                thing = JsonSerializer.Deserialize<ThingType>(body);
            }
            catch (Exception ex) { return BadRequest(); }

            var result = await _context.Things.FirstOrDefaultAsync(t => t.Id == thing.Id);

            if(result == null) { return BadRequest(); }

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpPost("Api/DeleteThing")]
        public async Task<IActionResult> DeleteThing(CancellationToken cancellationToken = default)
        {
            string body;
            using (var reader = new StreamReader(Request.Body))
                body = await reader.ReadToEndAsync();
            ThingType thing;
            try
            {
                thing = JsonSerializer.Deserialize<ThingType>(body);
            }
            catch (Exception ex) { return BadRequest(); }

            var result = await _context.Things.FirstOrDefaultAsync(t => t.Id == thing.Id);

            if (result == null) { return BadRequest(); }

            _context.Things.Remove(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Api/AddStock")]
        public async Task<IActionResult> AddStock(CancellationToken cancellationToken = default)
        {
            string body;
            using (var reader = new StreamReader(Request.Body))
                body = await reader.ReadToEndAsync();
            Stock stock;
            try
            {
                stock = JsonSerializer.Deserialize<Stock>(body);
            }
            catch (Exception ex) { return BadRequest(); }

            var context = new ValidationContext(stock);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(stock, context, results, true))
            {
                return BadRequest();
            }

            var exist = await _context.Stocks.Where(t => t.Id == stock.Id).FirstOrDefaultAsync();
            if (exist != null)
                _context.Stocks.Remove(exist);
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Api/GetStocks")]
        public async Task<IActionResult> GetStocks(CancellationToken cancellationToken = default)
        {
            var things = await _context.Stocks.AsNoTracking().ToListAsync();
            return Ok(JsonSerializer.Serialize(things));
        }

        [HttpPost("Api/GetStock")]
        public async Task<IActionResult> GetStock(CancellationToken cancellationToken = default)
        {
            string body;
            using (var reader = new StreamReader(Request.Body))
                body = await reader.ReadToEndAsync();
            Stock thing;
            try
            {
                thing = JsonSerializer.Deserialize<Stock>(body);
            }
            catch (Exception ex) { return BadRequest(); }

            var result = await _context.Stocks.FirstOrDefaultAsync(t => t.Id == thing.Id);

            if (result == null) { return BadRequest(); }

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpPost("Api/DeleteStock")]
        public async Task<IActionResult> DeleteStock(CancellationToken cancellationToken = default)
        {
            string body;
            using (var reader = new StreamReader(Request.Body))
                body = await reader.ReadToEndAsync();
            Stock thing;
            try
            {
                thing = JsonSerializer.Deserialize<Stock>(body);
            }
            catch (Exception ex) { return BadRequest(); }

            var result = await _context.Stocks.FirstOrDefaultAsync(t => t.Id == thing.Id);

            if (result == null) { return BadRequest(); }

            _context.Stocks.Remove(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Api/CreateItem")]
        public async Task<IActionResult> CreateItem(CancellationToken cancellationToken = default)
        {

            string body;
            using (var reader = new StreamReader(Request.Body))
                body = await reader.ReadToEndAsync();
            Item item;
            try
            {
                item = JsonSerializer.Deserialize<Item>(body);
            }
            catch (Exception ex) { return BadRequest(); }

            var context = new ValidationContext(item);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(item, context, results, true))
            {
                return BadRequest();
            }

            if(!await _context.Stocks.Where(s=>s.Id==item.StockId).AnyAsync()) return BadRequest();
            if(!await _context.Things.Where(s=>s.Id==item.TypeId).AnyAsync()) return BadRequest();

            var exist = await _context.Items.Where(t => t.Id == item.Id).FirstOrDefaultAsync();
            if (exist != null)
            {
                _context.Transactions.Add(new StockTransaction() { StockId = exist.StockId, Count = -1, ItemId = item.Id, Timestamp = DateTime.Now });
                exist.StockId = item.StockId;
            }
            else 
                _context.Items.Add(item);
            _context.Transactions.Add(new StockTransaction() { StockId = item.StockId, Count = 1, ItemId = item.Id, Timestamp = DateTime.Now }) ;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Api/DeleteItem")]
        public async Task<IActionResult> DeleteItem(CancellationToken cancellationToken = default)
        {
            string body;
            using (var reader = new StreamReader(Request.Body))
                body = await reader.ReadToEndAsync();
            Item thing;
            try
            {
                thing = JsonSerializer.Deserialize<Item>(body);
            }
            catch (Exception ex) { return BadRequest(); }

            var result = await _context.Items.FirstOrDefaultAsync(t => t.Id == thing.Id);

            if (result == null) { return BadRequest(); }

            _context.Items.Remove(result);
            _context.Transactions.Add(new StockTransaction() { StockId = result.StockId, Count = -1, ItemId = result.Id, Timestamp = DateTime.Now });
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Api/GetItemsOnStock")]
        public async Task<IActionResult> GetItemsOnStock(CancellationToken cancellationToken = default)
        {
            string body;
            using (var reader = new StreamReader(Request.Body))
                body = await reader.ReadToEndAsync();
            Stock thing;
            try
            {
                thing = JsonSerializer.Deserialize<Stock>(body);
            }
            catch (Exception ex) { return BadRequest(); }

            var result = await _context.Items.Where(t => t.StockId == thing.Id).ToListAsync();

            return Ok(JsonSerializer.Serialize(result));
        }
    }
}
