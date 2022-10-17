using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Models
{
    public class GetModelResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string CarTypeName { get; set; }
        public string FuelName { get; set; }
    }
}
