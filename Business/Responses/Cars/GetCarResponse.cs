using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Cars
{
    public class GetCarResponse
    {
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public int Kilometer { get; set; }
        public string Plate { get; set; }
        public string ModelName { get; set; }
        public string CarStateName { get; set; }
    }
}
