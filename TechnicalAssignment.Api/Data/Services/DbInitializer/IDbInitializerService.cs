namespace TechnicalAssignment.Api.Data.Services.DbInitializer
{
    public interface IDbInitializerService
    {
        void Migrate();
        void Seed();
    }
}
