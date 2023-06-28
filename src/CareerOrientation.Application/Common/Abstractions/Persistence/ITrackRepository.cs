using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Application.Common.Abstractions.Persistence;

public interface ITrackRepository : IRepositoryBase
{
    Task<Track?> GetTrackByName(string? name);
}