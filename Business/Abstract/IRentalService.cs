using Business.Requests.Rentals;
using Business.Responses.Rentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        GetRentalResponse GetById(int id);
        List<ListRentalResponse> GetList();
        void Add(CreateRentalRequest request);
        void Delete(DeleteRentalRequest request);
        void Update(UpdateRentalRequest request);
        //List<ListRentalResponse> GetRentDate(DateTime date);
        //List<ListRentalResponse> GetRentDateReturnDate(DateTime rentDate,DateTime returnDate);
    }
}
