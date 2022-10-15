using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Model : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int FuelId { get; set; }
        public int CarTypeId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public int DailyPrice { get; set; }
        public Brand brand { get; set; }
        public Fuel fuel { get; set; }
        public CarType carType { get; set; }
        public Color color { get; set; }

    }
}
