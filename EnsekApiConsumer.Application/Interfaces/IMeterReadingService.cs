using EnsekApiConsumer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekApiConsumer.Application.Interfaces;

//SOLID: Single Responsibility Principle (defines specific operations)
public interface IMeterReadingService
{
    Task<List<MeterReading>> GetMeterReadingsAsync();
    Task<bool> UploadMeterReadingsAsync(IEnumerable<MeterReading> readings);

    //get list
    Task<IEnumerable<MeterReading>> GetAllMeterReadingsAsync();
}
