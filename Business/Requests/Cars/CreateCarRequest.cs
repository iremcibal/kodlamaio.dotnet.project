using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Cars
{
    public class CreateCarRequest
    {
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public int Kilometer { get; set; }
        public string Plate { get; set; }
        public int ModelId { get; set; }
        public int CarStateId { get; set; }

    }
}
