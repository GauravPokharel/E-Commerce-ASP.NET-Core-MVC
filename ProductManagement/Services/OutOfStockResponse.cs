using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Services
{
    public class OutOfStockResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> ProductNames { get; set; }
    }
}
