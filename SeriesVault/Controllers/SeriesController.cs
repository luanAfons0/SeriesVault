using Microsoft.AspNetCore.Mvc;

namespace SeriesVault.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeriesController : ControllerBase
    {
        static private List<Series> _seriesList = new List<Series>();
        
        [HttpGet(Name = "GetSeries")]
        public ActionResult<Series[]> GetSeries()
        {
            return Ok(_seriesList);
        }

        [HttpGet("api/[controller]/{id}")]
        public ActionResult<Series> GetSeriesById(int id)
        {
            Series? item = _seriesList.FirstOrDefault(s => s.id == id);

            if (item is null)
                return NotFound();
            
            return Ok(_seriesList[id - 1]);
        }

        [HttpPost("api/[controller]")]
        public ActionResult<Series> PostSeries(Series? item)
        {
            if(item is null)
                return BadRequest();
            
            item.id = _seriesList.Count + 1;
            _seriesList.Add(item);

            return CreatedAtAction(nameof(GetSeriesById), new { id = item.id }, item);
        }

        [HttpPut("api/[controller]/{id}")]
        public ActionResult<Series> PutSeries(int id, Series? newItemValues)
        {
            if(newItemValues is null)
                return BadRequest();
            
            Series? itemToUpdate = _seriesList.FirstOrDefault(s => s.id == id);

            if (itemToUpdate is null)
                return NotFound();
            
            itemToUpdate.Title = newItemValues.Title;
            itemToUpdate.Platform = newItemValues.Platform;
            itemToUpdate.Producer = newItemValues.Producer;
            itemToUpdate.Publisher = newItemValues.Publisher;
            
            return NoContent();
        }

        [HttpDelete("api/[controller]/{id}")]
        public ActionResult<Series> DeleteSeries(int id)
        {
            Series? itemToDelete = _seriesList.FirstOrDefault(s => s.id == id);
            if (itemToDelete is null)
                return NotFound();
            
            _seriesList.Remove(itemToDelete);
            
            return NoContent();
        }
    }
}
