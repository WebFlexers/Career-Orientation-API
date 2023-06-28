using CareerOrientation.Domain.Entities;
using CareerOrientation.Infrastructure.Persistence.Repositories;

namespace CareerOrientation.Application.Common.Abstractions.Persistence;

public interface ITrackRepository : IRepositoryBase
{
    Task<Track?> GetTrackByName(string? name);
}