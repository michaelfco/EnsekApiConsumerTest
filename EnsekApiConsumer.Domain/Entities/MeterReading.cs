using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekApiConsumer.Domain.Entities;

//SOLID: Single Responsibility Principle 
public class MeterReading
{
    public int AccountId { get; set; }    
    public DateTime MeterReadingDateTime { get; set; }
    public string MeterReadValue { get; set; }
}
