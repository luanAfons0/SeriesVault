using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeriesVault.Data;

namespace SeriesVault.Controllers
{
    [ApiController]
    [Route("api/")]
    public class SeriesController(SeriesDbContext seriesDBContext) : ControllerBase
    {
        private readonly SeriesDbContext _dbContext = seriesDBContext;
        
        [HttpGet("series")]
        public async Task<ActionResult<List<Series>>> GetSeries()
        {
            return Ok(await _dbContext.Series.ToListAsync());
        }

        [HttpGet("series/{id}")]
        public ActionResult<Series> GetSeriesById(int id)
        {
            Series? item = _dbContext.Series.Find(id);
        
            if (item is null)
                return NotFound();
            
            return Ok(item);
        }
        
        [HttpPost("series/create")]
        public async Task<ActionResult<Series>> PostSeries(Series? item)
        {
            if(item is null)
                return BadRequest();

            _dbContext.Series.Add(item);
            await _dbContext.SaveChangesAsync();
        
            return CreatedAtAction(nameof(GetSeriesById), new { id = item.id }, item);
        }
        
        [HttpPut("series/update/{id}")]
        public async Task<ActionResult<Series>> PutSeries(int id, Series? newItemValues)
        {
            if(newItemValues is null)
                return BadRequest();
            
            Series? itemToUpdate = _dbContext.Series.Find(id);
        
            if (itemToUpdate is null)
                return NotFound();
            
            itemToUpdate.Title = newItemValues.Title;
            itemToUpdate.Platform = newItemValues.Platform;
            itemToUpdate.Producer = newItemValues.Producer;
            itemToUpdate.Publisher = newItemValues.Publisher;

            await _dbContext.SaveChangesAsync();
            
            return NoContent();
        }
        
        [HttpDelete("series/delete/{id}")]
        public async Task<ActionResult<Series>> DeleteSeries(int id)
        {
            Series itemToDelete = _dbContext.Series.Find(id);
            
            if (itemToDelete is null)
                return NotFound();
            
            _dbContext.Series.Remove(itemToDelete);
            await _dbContext.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
