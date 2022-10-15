using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Models
{
    public class CreateModelRequest
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int FuelId { get; set; }
        public int CarTypeId { get; set; }
        public int ColorId { get; set; }
        public int DailyPrice { get; set; }
    }
}
