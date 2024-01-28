using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using TechnicalAssignment.Api.Data;
using TechnicalAssignment.Api.Models.Integration;
using TechnicalAssignment.Api.Services.Interfaces;

namespace TechnicalAssignment.Api.Services
{
    public class IntegrationService : IIntegrationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public IntegrationService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<List<string>> GetModelsForMakeIdAndYear(long makeId, int modelYear)
        {
            string apiUrl = _configuration["ExternalApi:ModelsUrl"].ToString();

            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                string fullApiUrl = $"{apiUrl}/makeId/{makeId}/modelyear/{modelYear}?format=json";

                HttpResponseMessage response = await httpClient.GetAsync(fullApiUrl);
                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();

                var responseModels = JsonConvert.DeserializeObject<IntegrationModelsResponse>(responseContent);
                var models = responseModels?.Results.Select(e => e.Model_Name).ToList() ?? new();

                return models;
            }
        }
    }
}
