using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeriesVault.Data;
using SeriesVault.Services;

namespace SeriesVault.Controllers
{
    [ApiController]
    [Route("api/")]
    public class SeriesController(SeriesService seriesService) : ControllerBase
    {
        [HttpGet("series")]
        public async Task<ActionResult<List<Series>>> GetSeries()
        {
            return Ok(await seriesService.GetAllSeries());
        }

        [HttpGet("series/{id}")]
        public ActionResult<Series> GetSeriesById(int id)
        {
            Series? item = seriesService.GetSeriesById(id);
        
            if (item is null)
                return NotFound();
            
            return Ok(item);
        }
        
        [HttpPost("series/create")]
        public async Task<ActionResult<Series>> PostSeries(Series? item)
        {
            if(item is null)
                return BadRequest();

            await seriesService.CreateSeries(item);
        
            return CreatedAtAction(nameof(GetSeriesById), new { id = item.id }, item);
        }
        
        [HttpPut("series/update/{id}")]
        public async Task<ActionResult<Series>> PutSeries(int id, Series? newItemValues)
        {
            if(newItemValues is null)
                return BadRequest();
            
            Series? itemToUpdate = seriesService.GetSeriesById(id);
        
            if (itemToUpdate is null)
                return NotFound();
            
            await seriesService.UpdateSeries(itemToUpdate, newItemValues);
            
            return NoContent();
        }
        
        [HttpDelete("series/delete/{id}")]
        public async Task<ActionResult<Series>> DeleteSeries(int id)
        {
            Series? itemToDelete = seriesService.GetSeriesById(id);
            
            if (itemToDelete is null)
                return NotFound();

            await seriesService.DeleteSeries(itemToDelete);
            
            return NoContent();
        }
    }
}
