using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public int Kilometer { get; set; }
        public string Plate { get; set; }
        public int ModelId { get; set; }
        public int CarStateId { get; set; }
        public virtual Model Model { get; set; }
        public virtual CarState carState { get; set; }

    }
}
