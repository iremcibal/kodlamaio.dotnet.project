using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Rentals
{
    public class GetRentalResponse
    {
        public int CarId { get; set; }
        public string companyName { get; set; }
        public string carName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int BillNumber { get; set; }
        public int RentTotal { get; set; }
        public int PriceTotal { get; set; }
    }
}
