using Microsoft.EntityFrameworkCore;

namespace TechnicalAssignment.Api.Data.Services.DbInitializer
{
    public class DbInitializerService : IDbInitializerService
    {
        #region Fields

        private readonly ApplicationDbContext _applicationContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        #endregion Fields

        #region Constructor

        public DbInitializerService(ApplicationDbContext applicationContext, IWebHostEnvironment webHostEnvironment)
        {
            _applicationContext = applicationContext;
            _webHostEnvironment = webHostEnvironment;
        }

        #endregion Constructor

        #region Public Methods

        public void Migrate()
        {
            _applicationContext.Database.Migrate();
        }

        public void Seed()
        {
            var carMakes = _applicationContext.CarMakes;
            if (carMakes is null || !carMakes.Any())
            {
                var filePath = Path.Combine(this._webHostEnvironment.ContentRootPath, "Data/Seeding/CarMake.sql");
                if (System.IO.File.Exists(filePath))
                {
                    var scriptText = System.IO.File.ReadAllText(filePath);
                    _applicationContext.Database.ExecuteSqlRaw(scriptText);
                }
            }
        }

        #endregion Public Methods

    }
}