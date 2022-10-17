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
        public virtual Brand brand { get; set; }
        public virtual Fuel fuel { get; set; }
        public virtual CarType carType { get; set; }
        public virtual Color color { get; set; }


    }
}
