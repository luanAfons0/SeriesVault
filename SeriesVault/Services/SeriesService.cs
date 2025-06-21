using Microsoft.EntityFrameworkCore;
using SeriesVault.Data;

namespace SeriesVault.Services;

public class SeriesService(SeriesDbContext seriesDbContext)
{
    public async Task<List<Series>> GetAllSeries()
    {
        return (await seriesDbContext.Series.ToListAsync()).ToList();
    }

    public Series? GetSeriesById(int id)
    {
        return seriesDbContext.Series.Find(id);
    }

    public async Task<int> CreateSeries(Series series)
    {
        seriesDbContext.Series.Add(series);
        return await seriesDbContext.SaveChangesAsync();
    }

    public async Task UpdateSeries(Series itemToUpdate,Series newItemValues)
    {
        itemToUpdate.Title = newItemValues.Title;
        itemToUpdate.Platform = newItemValues.Platform;
        itemToUpdate.Producer = newItemValues.Producer;
        itemToUpdate.Publisher = newItemValues.Publisher;
        
        await seriesDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteSeries(Series seriesToDelete)
    {
        seriesDbContext.Series.Remove(seriesToDelete);
        return await seriesDbContext.SaveChangesAsync();
    }
}