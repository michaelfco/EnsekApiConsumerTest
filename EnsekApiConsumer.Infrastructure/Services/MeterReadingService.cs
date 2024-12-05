using EnsekApiConsumer.Application.Interfaces;
using EnsekApiConsumer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EnsekApiConsumer.Infrastructure.Services;

//SOLID: Dependency Inversion Principle (MeterReadingService depends on the IMeterReadingService)
//DP: Repository Pattern (abstracts data access (HTTP requests) and can be swapped for another data source)
public class MeterReadingService : IMeterReadingService
{
    private readonly HttpClient _httpClient;

    //public MeterReadingService(HttpClient httpClient)
    //{
    //    _httpClient = httpClient;
    //}
    public MeterReadingService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<List<MeterReading>> GetMeterReadingsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<MeterReading>>("/meter-readings");
        //?? if response is null it return a new list
        return response ?? new List<MeterReading>();
    }

    public async Task<bool> UploadMeterReadingsAsync(IEnumerable<MeterReading> readings)
    {
        var response = await _httpClient.PostAsJsonAsync("/meter-reading-uploads", readings);
        return response.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<MeterReading>> GetAllMeterReadingsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<MeterReading>>("/all-meter-readings");
        return response ?? new List<MeterReading>();
    }
}
