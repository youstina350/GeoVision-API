using GeoVision.Application.DTOs.Nasa;

namespace GeoVision.Application.Interfaces.External;

public interface INasaService
{
    Task<ApodDto> GetAstronomyPictureAsync();
}