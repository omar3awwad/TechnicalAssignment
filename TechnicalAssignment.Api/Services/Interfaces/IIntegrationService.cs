namespace TechnicalAssignment.Api.Services.Interfaces
{
    public interface IIntegrationService
    {
        Task<List<string>> GetModelsForMakeIdAndYear(long makeId, int modelYear);
    }
}
