using CsvHelper;
using EnsekApiConsumer.Application.Interfaces;
using EnsekApiConsumer.Domain.Entities;
using EnsekApiConsumer.web.Models;
using EnsekApiConsumer.Web.Map;
using EnsekApiConsumer.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Globalization;
using System.Net.Http.Headers;

namespace EnsekApiConsumer.web.Controllers;

//SOLID: Single Responsibility Principle (controller handles only HTTP requests (business logic in service) )
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    //SOLID: Open/Closed Principle (depends on the IMeterReadingService)
    private readonly IMeterReadingService _meterReadingService;
    private readonly IHttpClientFactory _httpClientFactory;


    public HomeController(ILogger<HomeController> logger, IMeterReadingService meterReadingService, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _meterReadingService = meterReadingService;
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public IActionResult UploadFile()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        try
        {
            var client = _httpClientFactory.CreateClient();

            using var content = new MultipartFormDataContent();
            using var fileStream = file.OpenReadStream();
            var fileContent = new StreamContent(fileStream);

            fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            content.Add(fileContent, "file", file.FileName);

            var response = await client.PostAsync("https://localhost:7051/meter-reading-uploads", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                TempData["SuccessMessage"] = $"File uploaded successfully! Response: {result}";
                return RedirectToAction("UploadFile");
                // return Ok($"File uploaded successfully! Response: {result}");
            }

            TempData["ErrorMessage"] = $"Failed to upload file. API responded with: {response.StatusCode}";
            return RedirectToAction("UploadFile");
            //return BadRequest($"Failed to upload file. API responded with: {response.StatusCode}");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Internal server error: {ex.Message}";
            return RedirectToAction("UploadFile");
            //return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var meterReadings = await _meterReadingService.GetAllMeterReadingsAsync();

            var viewModels = meterReadings.Select(r => new MeterReadingViewModel
            {
                AccountId = r.AccountId,
                MeterReadingDateTime = r.MeterReadingDateTime,
                MeterReadValue = r.MeterReadValue
            }).ToList();

            return View(viewModels);
        }
        catch (Exception ex)
        {
           
            return View("Error", ex.Message); 
        }
        
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
