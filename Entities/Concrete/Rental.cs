using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int BillNumber { get; set; }
        public int RentTotal { get; set; }
        public int PriceTotal { get; set; }
        public Car car { get; set; }
        public Customer customer { get; set; }



    }
}
