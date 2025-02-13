using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public interface IWalksRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    };
}
