using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.Infrastructure.Persistence.Repositories;

public class TrackRepository : RepositoryBase, ITrackRepository
{
    public TrackRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Track?> GetTrackByName(string? name)
    {
        if (name is null) return null;
        return await _dbContext.Tracks.FirstOrDefaultAsync(track => track.Name == name);
    }
}