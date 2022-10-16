using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Cars
{
    public class ListCarResponse
    {
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public int ModelId { get; set; }
        public int CarStateId { get; set; }
    }
}
