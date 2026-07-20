using GeoVision.Application.DTOs.Eonet;

namespace GeoVision.Application.Interfaces.External;

public interface IEonetService
{
    Task<List<EventDto>> GetEventsAsync(
        string? category = null,
        int? days = null,
        int? limit = null,
        int pageNumber = 1,  
        int pageSize = 10);  
}