namespace TechnicalAssignment.Api.Services.Interfaces
{
    public interface IMakeService
    {
        Task<long?> GetIdByName(string name);
    }
}
