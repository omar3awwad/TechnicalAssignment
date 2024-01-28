using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TechnicalAssignment.Api.Data;
using TechnicalAssignment.Api.Services.Interfaces;

namespace TechnicalAssignment.Api.Services
{
    public class MakeService : IMakeService
    {
        private readonly ApplicationDbContext _dbContext;

        public MakeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long?> GetIdByName(string name)
        {
            name = name?.ToUpper() ?? string.Empty;
            return (await _dbContext.CarMakes.FirstOrDefaultAsync(wh => wh.MakeName.Equals(name)))?.MakeId ?? null;
        }
    }
}
