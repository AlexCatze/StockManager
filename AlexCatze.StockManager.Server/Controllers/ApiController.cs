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

            _context.Things.Add(thing);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Api/GetThings")]
        public async Task<IActionResult> GetThings(CancellationToken cancellationToken = default)
        {
            var things = _context.Things.AsNoTracking().ToList();
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
        public async Task<IActionResult> Delete(CancellationToken cancellationToken = default)
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

    }
}
